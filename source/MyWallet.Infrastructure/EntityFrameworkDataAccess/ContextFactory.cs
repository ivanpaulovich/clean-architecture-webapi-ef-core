namespace MyWallet.Infrastructure.EntityFrameworkDataAccess {
    using System.IO;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public sealed class ContextFactory : IDesignTimeDbContextFactory<MyWalletContext> {
        public MyWalletContext CreateDbContext (string[] args) {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("autofac.production.json")
                .Build();
 
            DbContextOptionsBuilder<MyWalletContext> builder = new DbContextOptionsBuilder<MyWalletContext>();
            string connectionString = configuration
                .GetValue<string>("modules:2:properties:ConnectionString"); // this value is in the file MyWallet.WebApi/autofac.production.json

            System.Console.WriteLine($"Using the Connectionstring `{connectionString}`.");

            builder.UseSqlServer (connectionString);
            return new MyWalletContext (builder.Options);
        }
    }
}