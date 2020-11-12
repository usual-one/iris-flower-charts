using IrisFlowerCharts.Models;
using LiveCharts;
using LiveCharts.Wpf;
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

        private Dictionary<List<string>, double> euclideanDistances;

        private SeriesCollection sepalWidths;

        public SeriesCollection SepalWidths 
        { 
            get { return sepalWidths; }
            set
            {
                sepalWidths = value;
                NotifyPropertyChanged();
            }
        }

        private SeriesCollection sepalLengths;

        public SeriesCollection SepalLengths
        { 
            get { return sepalLengths; }
            set
            {
                sepalLengths = value;
                NotifyPropertyChanged();
            }
        }

        private SeriesCollection petalWidths;

        public SeriesCollection PetalWidths
        { 
            get { return petalWidths; }
            set
            {
                petalWidths = value;
                NotifyPropertyChanged();
            }
        }

        private SeriesCollection petalLengths;

        public SeriesCollection PetalLengths
        { 
            get { return petalLengths; }
            set
            {
                petalLengths = value;
                NotifyPropertyChanged();
            }
        }

        public Action CloseStartWindowAction { get; set; }

        public Action ShowMainWindowAction { get; set; }

        public Action ShowErrorWindowAction { get; set; } 

        public Main()
        {
            Calculator = new StatsCalculator();
            averageIrises = new List<Iris>();
            euclideanDistances = new Dictionary<List<string>, double>();
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
                            CreateCharts();
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

        public ICommand ReloadStatsCommand
        {
            get
            {
                if (reloadStatsCommand == null)
                    reloadStatsCommand = new Commands.DelegateCommand(o =>
                    {
                        try
                        {
                            LoadFile();
                            CalculateStats();
                            CreateCharts();
                        }
                        catch (Exception e)
                        {
                            ShowErrorWindowAction();
                            return;
                        }
                    });
                return reloadStatsCommand;
            }
        }

        private Commands.DelegateCommand reloadStatsCommand;

        private void CalculateStats()
        {
            averageIrises = Calculator.CalculateAverageIrises();
            euclideanDistances = Calculator.CalculateEuclideanDistances();
        }

        private void CreateCharts()
        {
            SepalWidths = new SeriesCollection();
            SepalLengths = new SeriesCollection();
            PetalWidths = new SeriesCollection();
            PetalLengths = new SeriesCollection();

            foreach (var iris in averageIrises)
            {
                SepalWidths.Add(new ColumnSeries
                {
                    Title = iris.Type,
                    Values = new ChartValues<double> 
                    { 
                        iris.Features[1]
                    } 
                });
                SepalLengths.Add(new ColumnSeries
                {
                    Title = iris.Type,
                    Values = new ChartValues<double> 
                    { 
                        iris.Features[0]
                    } 
                });
                PetalWidths.Add(new ColumnSeries
                {
                    Title = iris.Type,
                    Values = new ChartValues<double> 
                    { 
                        iris.Features[3]
                    } 
                });
                PetalLengths.Add(new ColumnSeries
                {
                    Title = iris.Type,
                    Values = new ChartValues<double> 
                    { 
                        iris.Features[2]
                    } 
                });
            }

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
