using System.Windows;
using System.Windows.Input;

namespace IrisFlowerCharts.Views
{
    /// <summary>Interaction logic for error window view. </summary>
    public partial class ErrorWindow : Window
    {
        /// <summary>Constructor.</summary>
        public ErrorWindow()
        {
            
            InitializeComponent();

            CloseButton.MouseDown += (sender, e) =>
            {
                Close();
            };

            ControlGrid.MouseDown += (sender, e) =>
            {
                if (e.ChangedButton == MouseButton.Left)
                    DragMove();
            };
        }
    }
}
