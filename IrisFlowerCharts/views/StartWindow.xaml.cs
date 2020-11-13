using System.Windows;
using System.Windows.Input;

namespace IrisFlowerCharts.Views
{
    /// <summary>Interaction logic for start window view.</summary>
    public partial class StartWindow : Window
    {
        /// <summary>Constructor.</summary>
        public StartWindow()
        {
            InitializeComponent();

            MinimizeButton.MouseDown += (sender, e) =>
            {
                WindowState = WindowState.Minimized;
            };

            CloseButton.MouseDown += (sender, e) =>
            {
                Application.Current.Shutdown();
            };

            ControlGrid.MouseDown += (sender, e) =>
            {
                if (e.ChangedButton == MouseButton.Left)
                    DragMove();
            };
        }
    }
}
