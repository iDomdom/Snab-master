using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using SnabBashka.Services;
using SnabBashka.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnabBashka
{
    class DependencyInjection
    {
        private static readonly ServiceProvider _provider;

        static DependencyInjection()
        {
            var services = new ServiceCollection();
            
            services.AddSingleton<MainViewModel>();
            services.AddTransient<MainPageViewModel>();

            services.AddSingleton<PageService>();
            services.AddSingleton(new LiteDatabase("Data/SupplyDepartment.db"));
            services.AddTransient<Repository>();




            _provider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => _provider.GetRequiredService<T>();
    }
}
