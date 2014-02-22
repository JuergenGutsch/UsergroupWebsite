using System.Collections.Generic;
using System.Web.Mvc;
using CommunitySite.Web.Data;
using CommunitySite.Web.Models;
using CommunitySite.Web.Services;
using FluentValidation;
using FluentValidation.Mvc;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Planning.Bindings;
using Ninject.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CommunitySite.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CommunitySite.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CommunitySite.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterValidation(kernel);
                RegisterServices(kernel);

                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

                
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterValidation(IKernel kernel)
        {
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new NinjectValidatorFactory(kernel);
            });
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InTransientScope();
            kernel.Bind<IEmailService>().To<EmailService>().InTransientScope();
            kernel.Bind<ISmtpService>().To<SmtpService>().InTransientScope();
        }
    }
    public class FluentValidatorModule : NinjectModule
    {
        public override void Load()
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<FluentValidatorModule>()
                .ForEach(match => Bind(match.InterfaceType).To(match.ValidatorType));
        }
    }

    public class NinjectValidatorFactory : ValidatorFactoryBase
    {
        /// <summary>
        /// Gets or sets the kernel.
        /// </summary> 
        /// <value>
        /// The kernel.
        /// </value>
        public IKernel Kernel { get; set; }

        /// <summary>
        /// Initializes a new instance of the NinjectValidatorFactory class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectValidatorFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

        /// <summary>
        /// Creates an instance of a validator with the given type using ninject. 
        /// </summary>
        /// <param name="validatorType">Type of the validator.</param>
        /// <returns>
        /// The newly created validator
        /// </returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            if (((ICollection<IBinding>)Kernel.GetBindings(validatorType)).Count == 0)
                return null;
            return Kernel.Get(validatorType, new IParameter[0]) as IValidator;
        }
    }
}
