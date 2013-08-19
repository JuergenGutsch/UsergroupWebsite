using System.Collections.Generic;
using System.Web.Mvc;
using CommunitySite.Web.Data;
using FluentValidation;
using FluentValidation.Mvc;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Planning.Bindings;
using Ninject.Syntax;
using Ninject.Web.Mvc;
using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;

[assembly: WebActivator.PreApplicationStartMethod(typeof(CommunitySite.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(CommunitySite.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CommunitySite.Web.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterValidation(kernel);
            
            RegisterServices(kernel);

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            return kernel;
        }

        private static void RegisterValidation(IKernel kernel)
        {
            var ninjectValidatorFactory = new NinjectValidatorFactory(kernel);
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(ninjectValidatorFactory));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }        
    }
    public class FluentValidatorModule : NinjectModule
    {
        public override void Load()
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<RepositoryConfig>()
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
