[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Socio.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Socio.App_Start.NinjectWebCommon), "Stop")]

namespace Socio.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Business.Managers.Implementations;
    using Business.Managers.Interfaces;
    using Data.Repository.Base.Interfaces;
    using Data.Repository;
    using Data.Repository.Base.Implementation;
    using Socio.DataNew.Contexts;
    using Socio.BusinessNew.Abstraction;
    using Socio.BusinessNew.Implementations;
    using Socio.DataNew;
    using Socio.BusinessNew.StoredImplementations;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static IKernel Kernel { get; set; }
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
                Kernel = kernel;
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
            kernel.Bind<DataContext>().To<DataContext>();
            kernel.Bind<IApplicationUnitOfWork>().To<ApplicationUnitOfWork>();
            kernel.Bind<IAccountManager>().To<AccountManager>();
            kernel.Bind<IUserAccountManager>().To<UserAccountManager>();
            kernel.Bind<IUserProfileManager>().To<UserProfileManager>();
            kernel.Bind<IConversationManager>().To<ConversationManager>();
            kernel.Bind<IMessageManager>().To<MessageManager>();
            kernel.Bind<IFeedMessageManager>().To<FeedMessageManager>();
            kernel.Bind<IManagerStore>().To<ManagerStore>();


            kernel.Bind<ISocioContext>().To<SocioContext>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();


            kernel.Bind<IAccountService>().To<SAccountService>();
            kernel.Bind<IConversationService>().To<SConversationService>();
            kernel.Bind<IProfileService>().To<SProfileService>();
            kernel.Bind<IMessageService>().To<SMessageService>();
            kernel.Bind<IFeedService>().To<SFeedService>();
            kernel.Bind<IEventsService>().To<SEventsService>();


            //kernel.Bind<IAccountService>().To<AccountService>();
            //kernel.Bind<IConversationService>().To<ConversationService>();
            //kernel.Bind<IProfileService>().To<ProfileService>();
            //kernel.Bind<IMessageService>().To<MessageService>();
            //kernel.Bind<IFeedService>().To<FeedService>();
        }        
    }
}
