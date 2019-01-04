using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartyInventoryManger.Services;
using System.Data.SqlClient;

namespace PartyInventoryManger
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            SqlConnection sql =DatabaseService.GetSqlConnection();
            List<string> scriptFileList = new List<string>();
            scriptFileList.Add(File.ReadAllText(@"D:\Programming\party-inventory-manger\party-inventory-manger\sql tables\dbo.CurrencyTable.sql"));
            scriptFileList.Add(File.ReadAllText(@"D:\Programming\party-inventory-manger\party-inventory-manger\sql tables\dbo.EconomyTable.sql"));
            scriptFileList.Add(File.ReadAllText(@"D:\Programming\party-inventory-manger\party-inventory-manger\sql tables\dbo.CurrencyCountTable.sql"));
            scriptFileList.Add(File.ReadAllText(@"D:\Programming\party-inventory-manger\party-inventory-manger\sql tables\dbo.WalletTable.sql"));

            foreach (string script in scriptFileList) {
                SqlCommand command = new SqlCommand(script, sql);
                command.ExecuteNonQuery();
            }

            sql.Close();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=CoinPurse}/{action=Home}/{id?}");
            });
        }
    }
}
