using IrisFlowerCharts.Models;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Input;

namespace IrisFlowerCharts.ViewModels
{
    public class Main : Base
    {
        private StatsCalculator Calculator;

        private List<Iris> averageIrises;

        public List<Iris> AverageIrises 
        { 
            get
            {
                return averageIrises;
            }
            set 
            {
                averageIrises = value;
                NotifyPropertyChanged();
            }
        }

        private Dictionary<List<string>, double> euclideanDistances;

        public Dictionary<List<string>, double> EuclideanDistances
        {
            get
            {
                return euclideanDistances;
            }
            set
            {
                euclideanDistances = value;
                NotifyPropertyChanged();
            }
        }

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
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "Comma Separated Values (*.csv)|*.csv"
            };


            if (fileDialog.ShowDialog() == true)
            {
                string path = fileDialog.FileName;
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
