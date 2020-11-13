using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IrisFlowerCharts.ViewModels
{
    /// <summary>Base view model class.</summary>
    /// <inheritdoc cref="INotifyPropertyChanged"/>
    public class Base : INotifyPropertyChanged { 
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies about changing the property.
        /// </summary>
        /// <param name="propertyName">Name of property that was changed.</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
