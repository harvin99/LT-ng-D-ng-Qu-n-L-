using Aspose.Cells;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DA_LTUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<HoaDon> listhoadon;
        List<Product> listproduct;
        List<Invoice> listinvoice;
        public MainWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = this;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listproduct = new List<Product>();
            listhoadon = new List<HoaDon>();
            billListView.ItemsSource = listhoadon.ToList();
            //Load SP Tu Database
            LoadProducts();
            LoadInvoices();

        }
        /// <SanPham
        private async void btimprot_SP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var screen = new OpenFileDialog();
                if (screen.ShowDialog() == true)
                {
                    var workbook = new Workbook(screen.FileName);
                    var tabs = workbook.Worksheets;
                    var db = new QuanLyNongSanDBEntities();
                    foreach (var tab in tabs)//Duyet Qua Tung Tab
                    {
                        if (tab.Name == "Nông Sản")
                        {
                            var col = 'A';
                            var row = 3;
                            var cell = tab.Cells[$"{ col}{ row}"];
                            while (cell.Value != null)//Duyet Qua Tung Dong
                            {
                                var id = tab.Cells[$"A{row}"].IntValue;
                                var name = tab.Cells[$"B{row}"].StringValue;
                                var Gia = tab.Cells[$"C{row}"].FloatValue;
                                var StrImage = tab.Cells[$"D{row}"].StringValue;

                                //lay duong dan cu Foder anh
                                var srcImageInfo = new FileInfo(screen.FileName);
                                var srcPath = $"{srcImageInfo.DirectoryName}\\ImagesProduct\\{StrImage}";
                                var sourceImageInfo = new FileInfo(srcPath);

                                //Tao ten duy nhat
                                var uniqueName = $"{Guid.NewGuid()}{sourceImageInfo.Extension}";

                                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                                var desPath = $"{basePath}Image_Product\\{uniqueName}";
                                if (!File.Exists(desPath))
                                {
                                    File.Copy(srcPath, desPath);
                                }


                                var newPro = new Product()
                                {
                                    Id = id,
                                    Name = name,
                                    Gia = Gia,
                                    Image = uniqueName
                                };
                                db.Products.Add(newPro);

                                await db.SaveChangesAsync();


                                row++;
                                cell = tab.Cells[$"{ col}{ row}"];
                            }
                        }
                    }
                    listproduct = db.Products.ToList();
                    // Update Datagrid
                    productdatagrid.ItemsSource = listproduct.ToList();
                    tbCountSp.Text = listproduct.Count().ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        
        private void btinsert_Click(object sender, RoutedEventArgs e)
        {
            var creen = new NhapSP(productdatagrid);
            creen.ShowDialog();
            LoadProducts();
        }
        
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Product prd = productdatagrid.SelectedItem as Product;
            if (prd != null && prd.Name != null)
            {
                var creen = new EditSP(prd, productdatagrid);
                this.IsEnabled = false;
                creen.ShowDialog();
                this.IsEnabled = true;
            }
            LoadProducts();
        }

        private void LoadProducts()
        {
            var db = new QuanLyNongSanDBEntities();
            listproduct = db.Products.ToList();
            //Load Datagrid
            productdatagrid.ItemsSource = listproduct.ToList();
            tbCountSp.Text = listproduct.Count().ToString();
        }
        private void tbfilter_productname_TextChanged(object sender, TextChangedEventArgs e)
        {
                var keyword = tbfilter_productname.Text;
                var data = from product in listproduct
                           where product.Name.ToLower().AccentRemoved().Contains(keyword.ToLower())
                           select product;
                productdatagrid.ItemsSource = data;
        }
        /// </SanPham>



        ///<HoaDon>
        private void btnNhapHD_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var creen = new NhapHD(listproduct, listhoadon);
            creen.ShowDialog();
            this.IsEnabled = true;
            LoadInvoices();
        }
        private void LoadInvoices()
        {
            var db = new QuanLyNongSanDBEntities();
            listinvoice = db.Invoices.ToList();
            var list = db.InvoiceStatus.ToList();
            //Load Datagrid
            billListView.ItemsSource = listinvoice.ToList();
        }
        private void billListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Invoice hd = billListView.SelectedItem as Invoice;
            if (hd != null && hd.NgayTao != null)
            {
                var creen = new EditHD(hd, listproduct);
                this.IsEnabled = false;
                creen.ShowDialog();
                this.IsEnabled = true;
            }
            LoadInvoices();
        }
        private void tbfilter_idinvoice_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = tbfilter_idinvoice.Text;
            var data = from invoice in listinvoice
                       where invoice.Id.ToString().ToLower().AccentRemoved().Contains(keyword.ToLower())
                       select invoice;
            billListView.ItemsSource = data;
        }
        private void btimprot_HD_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var wookbook = new Workbook(openFileDialog.FileName);
                var tabs = wookbook.Worksheets;
                using (var db = new QuanLyNongSanDBEntities())
                {
                    foreach (var tab in tabs)
                    {
                        try
                        {
                            if (tab.Name == "InvoiceStatus")
                            {
                                var col = 'B';
                                var row = 3;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {
                                    var key = tab.Cells[$"C{row}"].IntValue;
                                    var tinhtrang = tab.Cells[$"D{row}"].StringValue;

                                    var newInvoiceStatus = new InvoiceStatu()
                                    {
                                        Key = key,
                                        Value = tinhtrang,
                                    };
                                    db.InvoiceStatus.Add(newInvoiceStatus);

                                    db.SaveChanges();

                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    foreach (var tab in tabs)
                    {
                        try
                        {
                            if (tab.Name == "Invoice")
                            {
                                var col = 'B';
                                var row = 3;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {
                                    var tenkh = tab.Cells[$"C{row}"].StringValue;
                                    var diachikh = tab.Cells[$"D{row}"].StringValue;
                                    var sdt = tab.Cells[$"E{row}"].StringValue;
                                    var ngaytao = tab.Cells[$"F{row}"].StringValue;
                                    var ngayupdate = tab.Cells[$"G{row}"].StringValue;
                                    var tongtien = tab.Cells[$"H{row}"].DoubleValue;
                                    var idloai = tab.Cells[$"I{row}"].IntValue;

                                    var newInvoice = new Invoice()
                                    {
                                        TenKH = tenkh,
                                        DiaChiKH = diachikh,
                                        SDT = sdt,
                                        NgayTao = ngaytao,
                                        NgayUpdate = ngayupdate,
                                        TongTien = tongtien,
                                        IdStatus = idloai
                                    };
                                    db.Invoices.Add(newInvoice);

                                    db.SaveChanges();

                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                    }
                    foreach (var tab in tabs)
                    {
                        try
                        {
                            if (tab.Name == "InvoiceDetail")
                            {
                                var col = 'B';
                                var row = 3;
                                var cell = tab.Cells[$"{ col}{ row}"];
                                while (cell.Value != null)
                                {
                                    var idinvoice = tab.Cells[$"C{row}"].IntValue;
                                    var idproduct = tab.Cells[$"D{row}"].IntValue;
                                    var soluong = tab.Cells[$"E{row}"].IntValue;
                                    var giaban = tab.Cells[$"F{row}"].DoubleValue;
                                    var tongtien = tab.Cells[$"G{row}"].DoubleValue;

                                    var newInvoiceDetail = new InvoiceDetail()
                                    {
                                        IdInvoice = idinvoice,
                                        IdProduct = idproduct,
                                        SoLuong = soluong,
                                        GiaBan = giaban, 
                                        TongTien = tongtien
                                    };
                                    db.InvoiceDetails.Add(newInvoiceDetail);

                                    db.SaveChanges();

                                    row++;
                                    cell = tab.Cells[$"{ col}{ row}"];
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                LoadInvoices();
            }
        }
        ///</HoaDon>
        private void btimprot_NV_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
