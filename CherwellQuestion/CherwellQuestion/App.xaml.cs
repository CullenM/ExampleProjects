using System.Windows;
using ViewModels.CherwellQuestion;

namespace CherwellQuestion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel viewModel = new MainViewModel();
        }
    }
}
