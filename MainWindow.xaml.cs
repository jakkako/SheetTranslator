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
            StringBuilder convertedSheet = new StringBuilder(source);
            string targetDir = System.IO.Path.GetDirectoryName(sourcePath.Text);
            int counter = 0;
            foreach (char c in source)
            {
                switch (c)
                {
                    case '1':
                    case '8':
                    case 't':
                    case 's':
                    case 'l':
                    case 'm':
                        convertedSheet[counter] = 'c'; 
                        break;
                    case '!':
                    case '*':
                    case 'T':
                    case 'S':
                    case 'L':
                    case 'M':
                        convertedSheet[counter] = 'C';
                        break;
                    case '2':
                    case '9':
                    case 'y':
                    case 'd':
                    case 'z':
                        convertedSheet[counter] = 'd';
                        break;
                    case '@':
                    case '(':
                    case 'Y':
                    case 'D':
                    case 'Z':
                        convertedSheet[counter] = 'D';
                        break;
                    case '3':
                    case '0':
                    case 'u':
                    case 'f':
                    case 'x':
                        convertedSheet[counter] = 'e';
                        break;
                    case '4':
                    case 'q':
                    case 'i':
                    case 'g':
                    case 'c':
                        convertedSheet[counter] = 'f';
                        break;
                    case '$':
                    case 'Q':
                    case 'I':
                    case 'G':
                    case 'C':
                        convertedSheet[counter] = 'F';
                        break;
                    case '5':
                    case 'w':
                    case 'o':
                    case 'h':
                    case 'v':
                        convertedSheet[counter] = 'g';
                        break;
                    case '%':
                    case 'W':
                    case 'O':
                    case 'H':
                    case 'V':
                        convertedSheet[counter] = 'G';
                        break;
                    case '6':
                    case 'e':
                    case 'p':
                    case 'j':
                    case 'b':
                        convertedSheet[counter] = 'a';
                        break;
                    case '^':
                    case 'E':
                    case 'P':
                    case 'J':
                    case 'B':
                        convertedSheet[counter] = 'A';
                        break;
                    case '7':
                    case 'r':
                    case 'a':
                    case 'k':
                    case 'n':
                        convertedSheet[counter] = 'b';
                        break;
                    default:
                        convertedSheet[counter] = c;
                        break;

                }
                counter++;
            }
            File.WriteAllText($"{targetDir}\\{OutputFileName.Text}.txt", convertedSheet.ToString());
            MessageBox.Show($"Process complete!\nConverted sheet path:\n{targetDir}\\{OutputFileName.Text}.txt", "Process Complete", 0);

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
