//using System.Web.Mvc;
//using Autofac;
//using Autofac.Integration.Mvc;
//using CommunitySite.Web.Data;

//namespace CommunitySite.Web.App_Start
//{
//    public class IocConfig
//    {
//        public static void RegisterDependencies()
//        {
//            var currentAssembly = typeof(MvcApplication).Assembly;

//            var builder = new ContainerBuilder();

//            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
//            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork));

//            builder.RegisterControllers(currentAssembly);
//            builder.RegisterModelBinders(currentAssembly);
//            builder.RegisterModelBinderProvider();
//            builder.RegisterFilterProvider();
//            builder.RegisterModule(new AutofacWebTypesModule());

//            var container = builder.Build();
//            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
//        }
//    }
//}