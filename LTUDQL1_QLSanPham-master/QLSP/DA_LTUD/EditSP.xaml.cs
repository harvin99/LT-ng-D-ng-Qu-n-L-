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
using System.IO;
using Microsoft.Win32;
using System.Data.Entity;

namespace DA_LTUD
{
    /// <summary>
    /// Interaction logic for EditSP.xaml
    /// </summary>
    public partial class EditSP : Window
    {
        Product item;
        DataGrid data;
        Product it;
        string destinationPath;
        public EditSP(Product prd, DataGrid dt)
        {
            item = prd;
            data = dt;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
        private void btedit_Click(object sender, RoutedEventArgs e)
        {
            if(btedit.Content.ToString() == "Edit")
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

        private void btapply_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new QuanLyNongSanDBEntities())
            {
                this.IsEnabled = false;
                var creen = new ConfirmWindow($"Ban Co Chac Muon Edit San Phan {item.Id}");
                creen.ShowDialog();
                if (creen.DialogResult == true)
                {
                    var result = db.Products.SingleOrDefault(b => b.Id == it.Id);
                    if (result != null)
                    {
                        try
                        {
                            result.Name = it.Name;
                            result.Gia = it.Gia;
                            string pathDelete;
                            if (destinationPath != it.Image)
                            {
                                pathDelete = destinationPath;
                                //Đường Dẫn File Ảnh Gốc
                                var sourceImageFileInfo = new FileInfo(it.Image);

                                //Tao ten duy nhat
                                var uniqueName = $"{Guid.NewGuid()}{sourceImageFileInfo.Extension}";


                                //Đường dẫn tập tin exe
                                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                                //Đường dẫn folder Image trong file exe
                                destinationPath = $"{baseDirectory}Image_Product\\{uniqueName}";

                                //Copy Ảnh từ File Ảnh Gốc Sang Folder Ảnh Trong File Exe
                                if (!File.Exists(destinationPath))
                                {
                                    File.Copy(it.Image, destinationPath);
                                }
                                result.Image = uniqueName;
                                item.Image = uniqueName;
                            }
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    item.Equal(it);
                    it.Image = destinationPath;
                    stpShow.Height = stpEdit.Height;
                    stpEdit.Height = 0;
                    btedit.Content = "Edit";
                    btapply.IsEnabled = false;
                }
                this.IsEnabled = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            it = new Product();
            it.Equal(item);
            //Đường dẫn tập tin exe
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //Đường dẫn folder Image trong file exe
            destinationPath = $"{baseDirectory}Image_Product\\{item.Image}";

            it.Image = destinationPath;

            stpEdit.DataContext = it;
            stpShow.DataContext = item;
        }

        private void btdelete_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new QuanLyNongSanDBEntities())
            {
                this.IsEnabled = false;
                var creen = new ConfirmWindow($"Ban Co Chac Muon Xoa San Phan {item.Id}");
                creen.ShowDialog();
                if (creen.DialogResult == true)
                {
                    var itemdelete = db.Products.Find(item.Id);
                    db.Products.Remove(itemdelete);
                    db.SaveChanges();
                    this.Close();
                }
                this.IsEnabled = true;
            }
        }

        private void btchoosefile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                it.Image = openFileDialog.FileName;
            }
        }
    }
}
