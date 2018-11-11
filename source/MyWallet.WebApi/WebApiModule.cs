namespace MyWallet.WebApi {
    using Autofac;

    public class WebApiModule : Autofac.Module {
        protected override void Load (ContainerBuilder builder) {
            //
            // Register all Types in MyWallet.WebApi
            builder.RegisterAssemblyTypes (typeof (Startup).Assembly)
                .AsSelf ()
                .InstancePerLifetimeScope ();
        }
    }
}