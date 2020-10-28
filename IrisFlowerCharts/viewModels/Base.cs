﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IrisFlowerCharts.ViewModels
{
    public class Base : INotifyPropertyChanged { 
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
