using System;
using System.Windows;

namespace IrisFlowerCharts
{
    /// <summary>Interaction logic for global application.</summary>
    /// <inheritdoc cref="Application"/>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ViewModels.Main dataContext = new ViewModels.Main();

            Views.ErrorWindow errorWindow = null;

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
                dataContext.ShowErrorWindowAction = new Action(() => 
                {
                    if (errorWindow != null)
                    {
                        errorWindow.Close();
                    }

                    errorWindow = new Views.ErrorWindow()
                    {
                        DataContext = dataContext
                    };
                    errorWindow.Show();
                });

            startWindow.Show();
        }
    }
}
