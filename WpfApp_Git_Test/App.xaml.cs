using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_Git_Test
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        [STAThreadAttribute]
        public static void Main(string[] args)
        {

            var app = new App();
            app.InitializeComponent();
            //app._InitializeComponent();

            CloneWindow w = new CloneWindow();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //MainWindow w = new MainWindow();
            //app.Startup += app_Startup;
            app.Run(w);
        }
    }
}
