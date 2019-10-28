using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace SheetTranslator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OutputFileName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (OutputFileName.Text == this.FindResource("outputFileDEFAULT").ToString())
            {
                OutputFileName.Text = String.Empty;
                OutputFileName.Foreground = Brushes.Black;
            }
        }

        private void OutputFileName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (OutputFileName.Text == String.Empty)
            {
                OutputFileName.Text = this.FindResource("outputFileDEFAULT").ToString();
                OutputFileName.Foreground = Brushes.DimGray;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            baseGrid.Focus();
        }

        private void SourcePath_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sourcePath.Text == this.FindResource("sourcePathDEFAULT").ToString())
            {
                sourcePath.Text = String.Empty;
                sourcePath.Foreground = Brushes.Black;
            }
        }

        private void SourcePath_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sourcePath.Text == String.Empty)
            {
                sourcePath.Text = this.FindResource("sourcePathDEFAULT").ToString();
                sourcePath.Foreground = Brushes.DimGray;
            }
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                sourcePath.Text = openFileDialog.FileName;
            sourcePath.Foreground = Brushes.Black;
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            string source = File.ReadAllText(sourcePath.Text);
            string targetDir = System.IO.Path.GetDirectoryName(sourcePath.Text);
            File.Create($"{targetDir}\\{OutputFileName.Text}.txt");
           
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            sourcePath.Text = this.FindResource("sourcePathDEFAULT").ToString();
            sourcePath.Foreground = Brushes.DimGray;
            OutputFileName.Text = this.FindResource("outputFileDEFAULT").ToString();
            OutputFileName.Foreground = Brushes.DimGray;
        }
    }
}
