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

using WpfApp_Git_Test.Model;

namespace WpfApp_Git_Test
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GitClient.Test();

            MessageBox.Show("aa");
        }

        private void button_Clone_Click_1(object sender, RoutedEventArgs e)
        {
            CloneWindow w = new CloneWindow();
            w.Owner = this;

            w.ShowDialog();
        }
    }
}
