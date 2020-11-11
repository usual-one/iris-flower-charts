using IrisFlowerCharts.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IrisFlowerCharts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ViewModels.Main dataContext = new ViewModels.Main();

            Views.ErrorWindow errorWindow = new Views.ErrorWindow()
            {
                DataContext = dataContext
            };

            Views.MainWindow mainWindow = new Views.MainWindow()
            {
                DataContext = dataContext
            };

            Views.StartWindow startWindow = new Views.StartWindow()
            {
                DataContext = dataContext
            };

            if (dataContext.CloseStartWindowAction == null)
                dataContext.CloseStartWindowAction = new Action(() => startWindow.Close());

            if (dataContext.ShowMainWindowAction == null)
                dataContext.ShowMainWindowAction = new Action(() => mainWindow.Show());

            if (dataContext.ShowErrorWindowAction == null)
                dataContext.ShowErrorWindowAction = new Action(() => errorWindow.Show());

            startWindow.Show();
        }
    }
}
