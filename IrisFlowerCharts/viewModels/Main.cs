using IrisFlowerCharts.Models;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Input;

namespace IrisFlowerCharts.ViewModels
{
    public class Main : Base
    {
        private StatsCalculator Calculator;

        public List<Iris> AverageIrises { get; set; }

        public Dictionary<List<string>, double> EuclideanDistances { get; set; }

        public Main()
        {
            Calculator = new StatsCalculator();
            AverageIrises = new List<Iris>();
            EuclideanDistances = new Dictionary<List<string>, double>();
        }

        public ICommand LoadStatsCommand
        {
            get
            {
                if (loadStatsCommand == null)
                    loadStatsCommand = new Commands.DelegateCommand(o =>
                    {
                        LoadFile();
                        CalculateStats();
                    });
                return loadStatsCommand;
            }
        }

        private Commands.DelegateCommand loadStatsCommand;

        private void LoadFile()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "Comma Separated Values (*.csv)",
                InitialDirectory = "."
            };

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string path = dlg.FileName;
                Calculator.LoadIrises(path);
            }
            else
                return;
        }

        private void CalculateStats()
        {
            AverageIrises = Calculator.CalculateAverageIrises();
            EuclideanDistances = Calculator.CalculateEuclideanDistances();
        }
    }
}
