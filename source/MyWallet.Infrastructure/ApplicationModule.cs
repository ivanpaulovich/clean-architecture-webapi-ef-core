namespace MyWallet.Infrastructure {
    using Autofac;
    using MyWallet.Application;

    public class ApplicationModule : Module {
        protected override void Load (ContainerBuilder builder) {
            //
            // Register all Types in MyWallet.Application
            builder.RegisterAssemblyTypes (typeof (ApplicationException).Assembly)
                .AsImplementedInterfaces ()
                .InstancePerLifetimeScope ();
        }
    }
}