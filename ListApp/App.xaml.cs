using Microsoft.Extensions.DependencyInjection;
using ListApp.Interfaces;
using ListApp.Repositories;
using ListApp.Services;
using System.Windows;

namespace ListApp
{
    public partial class App : Application
    {
        private IServiceProvider? _provider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IFileDialogService, FileDialogService>();
            services.AddSingleton<ISerializerService, SerializerService>();
            services.AddSingleton<IRepository, FileRepository>();
            services.AddTransient<MainWindow>();

            _provider = services.BuildServiceProvider();

            MainWindow main = _provider.GetRequiredService<MainWindow>();
            main.Show();
        }
    }
}
