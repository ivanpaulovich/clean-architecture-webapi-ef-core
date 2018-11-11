namespace MyWallet.Infrastructure.EntityFrameworkDataAccess {
    using Autofac;
    using Microsoft.EntityFrameworkCore;

    public class EntityFrameworkModule : Autofac.Module {
        public string ConnectionString { get; set; }

        protected override void Load (ContainerBuilder builder) {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext> ();
            optionsBuilder.UseSqlServer (ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging (true);

            builder.RegisterType<MyWalletContext> ()
                .WithParameter (new TypedParameter (typeof (DbContextOptions), optionsBuilder.Options))
                .InstancePerLifetimeScope ();

            //
            // Register all Types in MongoDataAccess namespace
            builder.RegisterAssemblyTypes (typeof (InfrastructureException).Assembly)
                .Where (type => type.Namespace.Contains ("EntityFrameworkDataAccess"))
                .AsImplementedInterfaces ()
                .InstancePerLifetimeScope ();
        }
    }
}