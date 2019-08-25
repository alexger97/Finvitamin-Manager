using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinVitamin_Manager.Models.Context
{
    public class ProductContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderSpb>()
                .HasOne(p => p.CourerTask)
                .WithOne(i => i.OrderSpb).HasForeignKey<CourerTask>(b => b.OrderSpbId );

        }

        


        public DbSet<Product> Products { get; set; }


        public DbSet<OrderRegion> OrdersRegion { get; set; }

        public DbSet<OrderSpb> OrdersSpb { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Courer> Courers { get; set; }
        public DbSet<OrderProdust> OrderProdusts { get; set; }

        public DbSet<CourerTask> CourerTasks { get; set; }

        public DbSet<InvoiceForCourer> InvoiceForCourers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=sql6007.site4now.net;Initial Catalog=DB_A4B2A7_fv;User Id=DB_A4B2A7_fv_admin;Password=metro2033;");


            //("Data Source=SQL6007.site4now.net;Initial Catalog=DB_A4ACD7_productcontext2;User Id=DB_A4ACD7_productcontext2_admin;Password=metro2033;");


            //UseMySQL("Data Source=mysql8.db4free.net; database=productcontext;User ID=product_user;password=metro2033,port=3306");
            // .UseSqlServer($@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = {nameof(ProductContext)}; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

        }
        
    }
}
