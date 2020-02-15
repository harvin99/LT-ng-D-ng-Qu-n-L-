using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for NhapSP.xaml
    /// </summary>
    public partial class NhapSP : Window
    {
        DataGrid data;
        Product prd = new Product();
        public NhapSP(DataGrid dt)
        {
            data = dt;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.DataContext = prd;
        }

        private async void btadd_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new QuanLyNongSanDBEntities())
            {
                Product newprd = new Product();
                if (tbname.Text == "")
                {
                    MessageBox.Show("Ten San Pham Khong Duoc Trong");
                }
                else if (tbGia.Text == "0")
                {
                    MessageBox.Show("Gia San Pham Khong Duoc Trong");
                }
                else if (imgproduct.Source == null)
                {
                    MessageBox.Show("Chua Nhap Anh San Pham");
                }
                else
                {
                    newprd.Equal(prd);

                    //Đường Dẫn File Ảnh Gốc
                    var sourceImageFileInfo = new FileInfo(prd.Image);

                    //Tao ten duy nhat
                    var uniqueName = $"{Guid.NewGuid()}{sourceImageFileInfo.Extension}";

                    newprd.Image = uniqueName;

                    //Đường dẫn tập tin exe
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    //Đường dẫn folder Image trong file exe
                    var destinationPath = $"{baseDirectory}Image_Product\\{newprd.Image}";

                    //Copy Ảnh từ File Ảnh Gốc Sang Folder Ảnh Trong File Exe
                    if (!File.Exists(destinationPath))
                    {
                        File.Copy(prd.Image, destinationPath);
                    }

                    db.Products.Add(newprd);

                    await db.SaveChangesAsync();

                    MessageBox.Show("Thêm Sản Phẩm Thành Công");

                    prd.ResetValue();

                    data.ItemsSource = db.Products.ToList();
                }
            }
             
        }

        private void btchooseimage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                prd.Image = openFileDialog.FileName;
            }
        }

        private void btcancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
