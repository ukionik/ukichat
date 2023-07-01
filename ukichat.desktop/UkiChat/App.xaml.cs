using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using UkiChat.Configuration;
using UkiChat.Service;

namespace UkiChat
{
    public partial class App
    {
        private readonly ServiceProvider diProvider;

        public App()
        {
            diProvider = DIConfig.Init();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            InitApp();            
        }

        private void InitApp()
        {
            diProvider.GetService<IAppInitializationService>().Init();
        }
    }
}