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

namespace DA_LTUD
{
    /// <summary>
    /// Interaction logic for EditKH.xaml
    /// </summary>
    public partial class EditKH : Window
    {
        public EditKH()
        {
            InitializeComponent();
        }

        private void btedit_Click(object sender, RoutedEventArgs e)
        {
            if (btedit.Content.ToString() == "Edit")
            {
                stpEdit.Height = stpShow.Height;
                stpShow.Height = 0;
                btedit.Content = "Show";
                btapply.IsEnabled = true;
            }
            else
            {
                stpShow.Height = stpEdit.Height;
                stpEdit.Height = 0;
                btedit.Content = "Edit";
                btapply.IsEnabled = false;
                it.Equal(item);
            }
        }

        private void btdelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
