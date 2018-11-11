namespace MyWallet.Infrastructure.InMemoryDataAccess {
    using Autofac;

    public class InMemoryModule : Autofac.Module {
        protected override void Load (ContainerBuilder builder) {
            builder.RegisterType<MyWalletContext> ()
                .As<MyWalletContext> ()
                .SingleInstance ();
            //
            // Register all Types in InMemoryDataAccess namespace
            builder.RegisterAssemblyTypes (typeof (InfrastructureException).Assembly)
                .Where (type => type.Namespace.Contains ("InMemoryDataAccess"))
                .AsImplementedInterfaces ()
                .InstancePerLifetimeScope ();
        }
    }
}