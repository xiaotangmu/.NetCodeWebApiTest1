using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi1.Beans;
using WebApi1.Config;
using WebApi1.DB;
using WebApi1.Services;
using WebApi1.Services.Impl;
using System.ComponentModel;
using WebApi1.utils;
using WebApi1.Dao;
using Microsoft.Extensions.Logging;
using log4net.Repository.Hierarchy;

namespace WebTest2
{
    public class Startup
    {
        /// <summary>
        /// ���񼯺�
        /// </summary>
        private IServiceCollection _services;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ���÷���������ʱ������
        /// <para>
        /// �ڴ˷�������ӻ����÷���
        /// </para>
        /// </summary>
        /// <param name="services">���񼯺�</param>
        public void ConfigureServices(IServiceCollection services)
        {

            //������ÿ���ע��controller
            //services.Configure<TokenProviderOptions>(Configuration.GetSection("Jwt"));
            //TokenProviderOptions tokenOptions = new TokenProviderOptions();
            //Configuration.Bind("Jwt", tokenOptions);

            //JWTTokenValid(services);

            #region �������
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                      .AllowAnyOrigin() //.WithOrigins(new string[] {"",""})
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                .Build());
            });
            #endregion


            // ����ע��
            services.AddSingleton(Configuration);
            services.AddScoped<UserService, UserServiceImpl>();

            // ��������ļ��е����ݿ� ��ConnectionStrings �ڵ㣩 ������Ϣ
            Dictionary<string, string> dbType = Configuration.GetSection("ConnectionStrings")
                .Get<Dictionary<string, string>>();
            //DbConnType dbConnType = Configuration.GetSection("ConnectionStrings").Get<DbConnType>();
            DbConnTypeStorage.setDbConnType(dbType, DbTypeEnum.SqlServer.GetDescription());

            services.AddHttpClient();
            services.AddControllersWithViews();
            _services = services;
        }

        //private void JWTTokenValid(IServiceCollection services)
        //{
        //    services.AddAuthentication("Bearer")
        //                    .AddIdentityServerAuthentication(options =>
        //                    {
        //                        options.Authority = Configuration.GetSection("ADFS:ADFSDiscoveryDoc").Value;
        //                        options.RequireHttpsMetadata = false;
        //                        options.JwtBearerEvents = new JwtBearerEvents
        //                        {
        //                            OnTokenValidated = context =>
        //                            {
        //                                GenerateCurrentUser(context.Principal);
        //                                return Task.CompletedTask;
        //                            }
        //                        };
        //                    });
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
