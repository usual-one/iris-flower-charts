using IrisFlowerCharts.Models;
using Microsoft.Win32;
using System;
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

        public Action CloseStartWindowAction { get; set; }

        public Action ShowMainWindowAction { get; set; }

        public Action ShowErrorWindowAction { get; set; } 

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
                        try
                        {
                            LoadFile();
                            CalculateStats();
                        }
                        catch (Exception e)
                        {
                            ShowErrorWindowAction();
                            return;
                        }

                        CloseStartWindowAction();
                        ShowMainWindowAction();
                    });
                return loadStatsCommand;
            }
        }

        private Commands.DelegateCommand loadStatsCommand;

        private void CalculateStats()
        {
            AverageIrises = Calculator.CalculateAverageIrises();
            EuclideanDistances = Calculator.CalculateEuclideanDistances();
        }

        private void LoadFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "Comma Separated Values (*.csv)|*.csv",
                InitialDirectory = "X:\\Main\\Programming\\C#\\iris-flower-charts\\examples"
            };


            if (fileDialog.ShowDialog() == true)
            {
                string path = fileDialog.FileName;
                Calculator.LoadIrises(path);
            }
            else
                return;
        }

    }
}
