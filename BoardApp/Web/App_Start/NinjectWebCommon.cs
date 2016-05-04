using System;
using System.Web;
using DAL;
using DAL.Helpers;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Web
{
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

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<DataBaseContext>().InRequestScope();

            /*
            kernel.Bind<IMapPointRepository>().To<MapPointRepository>().InRequestScope();
            kernel.Bind<IRouteRepository>().To<RouteRepository>().InRequestScope();
            kernel.Bind<IEventRepository>().To<EventRepository>().InRequestScope();
            kernel.Bind<IRouteAndCharacteristicRepository>().To<RouteAndCharacteristicRepository>().InRequestScope();
            kernel.Bind<IRouteCharacteristicRepository>().To<RouteCharacteristicRepository>().InRequestScope();
            kernel.Bind<IRouteCommentRepository>().To<RouteCommentRepository>().InRequestScope();
            kernel.Bind<IRouteInEventRepository>().To<RouteInEventRepository>().InRequestScope();

            kernel.Bind<ITransportItemRepository>().To<TransportItemRepository>().InRequestScope();
            kernel.Bind<ITransportItemTypeRepository>().To<TransportItemTypeRepository>().InRequestScope();
            kernel.Bind<ITransportItemTypeAttributeRepository>().To<TransportItemTypeAttributeRepository>().InRequestScope();
            kernel.Bind<ITransportItemTypeAttributeValueRepository>().To<TransportItemTypeAttributeValueRepository>().InRequestScope();
            */

            kernel.Bind<EFRepositoryFactories>().To<EFRepositoryFactories>().InSingletonScope();
            kernel.Bind<IEFRepositoryProvider>().To<EFRepositoryProvider>().InRequestScope();
            kernel.Bind<IUOW>().To<UOW>().InRequestScope();
        }        
    }
}
