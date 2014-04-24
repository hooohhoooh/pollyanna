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
using System.Windows.Shapes;

namespace WpfApp_Git_Test
{
    /// <summary>
    /// CloneWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CloneWindow : Window
    {
        public CloneWindow()
        {
            InitializeComponent();
        }

        private void button_Execute_Click(object sender, RoutedEventArgs e)
        {
            string args = textBox_Args.Text;

            Model.GitClient.Execute(args);

        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = false;
            this.Close();
        }

        private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null && files.Length > 0)
                {
                    string file = files[0];

                    if (System.IO.Directory.Exists(file))
                    {
                        e.Effects = DragDropEffects.Copy;

                        e.Handled = true;
                    }
                }
            }

        }

        private void TextBox_PreviewDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (files != null && files.Length > 0)
            {
                string file = files[0];

                if (System.IO.Directory.Exists(file))
                {
                    TextBox tb = sender as TextBox;

                    tb.Text = file;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string src = textBox_Source.Text;
            string dest = textBox_Destination.Text;

            string cmd = @"clone --no-local --recursive {0} {1}";

            string s = string.Format(cmd, src, dest);

            textBox_Args.Text = s;

        }
    }
}
