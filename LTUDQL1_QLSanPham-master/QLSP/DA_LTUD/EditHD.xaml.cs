using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for EditHD.xaml
    /// </summary>
    public partial class EditHD : Window
    {
        Invoice HD;
        List<Product> listSP;
        List<InvoiceDetail> insert;
        List<InvoiceDetail> view;
        List<InvoiceDetail> delete;
        List<InvoiceDetail> update;
        public EditHD(Invoice hd, List<Product> listproduct)
        {
            HD = hd;
            listSP = listproduct;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void btedit_Click(object sender, RoutedEventArgs e)
        {
            if (btedit.Content.ToString() == "Edit")
            {
                stackpaneledit.Height = stackpanelshow.Height;
                LoadEdit();
                this.Width = 800;
                stackpanelshow.Height = 0;
                btedit.Content = "Show";
                btapply.IsEnabled = true;
                this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            }
            else
            {
                stackpanelshow.Height = stackpaneledit.Height;
                this.Width = 800;
                stackpaneledit.Height = 0;
                btedit.Content = "Edit";
                btapply.IsEnabled = false;
                //it.Equal(item);
            }
        }

        private async void btadd_Click(object sender, RoutedEventArgs e)
        {
            if (tbtenkh.Text == "")
            {
                MessageBox.Show("Tên Khách Hàng Không Được Trống");
                return;
            }
            else if (tbdiachi.Text == "")
            {
                MessageBox.Show("Địa Chỉ Khách Hàng Không Được Trống");
                return;
            }
            else if (tbsdt.Text == "")
            {
                MessageBox.Show("SĐT Khách Hàng Không Được Trống");
                return;
            }
            else if (tblngaydat.Text == "")
            {
                MessageBox.Show("Ngay Đạt Không Được Trống");
                return;
            }
            else if (view.Count == 0)
            {
                MessageBox.Show("Hóa Đơn Phải Có Ít Nhất 1 SP");
                return;
            }
            using (var db = new QuanLyNongSanDBEntities())
            {
                this.IsEnabled = false;
                var creen = new ConfirmWindow($"Ban Co Chac Muon Edit Hoa Don {HD.Id}");
                creen.ShowDialog();
                if (creen.DialogResult == true)
                {
                    var result = db.Invoices.SingleOrDefault(b => b.Id == HD.Id);
                    if (result != null)
                    {
                        result.TenKH = tbtenkh.Text;
                        result.DiaChiKH = tbdiachi.Text;
                        result.SDT = tbsdt.Text;
                        UpdateStatus(result);
                        result.TongTien = double.Parse(tbltongtienhoadon.Text);
                        foreach (var CT in result.InvoiceDetails)
                        {
                            foreach (var ct in view)
                            {
                                if (ct.Id == CT.Id && CT.SoLuong != ct.SoLuong)
                                {
                                    CT.SoLuong = ct.SoLuong;
                                    CT.TinhTongGia();
                                }
                            }
                        }
                        foreach(var CT in insert)
                        {
                            InvoiceDetail newDetail = new InvoiceDetail()
                            {
                                IdInvoice = CT.IdInvoice,
                                IdProduct = CT.IdProduct,
                                SoLuong = CT.SoLuong,
                                TongTien = CT.TongTien,
                                GiaBan = CT.GiaBan,
                            };
                            result.InvoiceDetails.Add(newDetail);
                            await db.SaveChangesAsync();
                        }
                        foreach(var delete in delete)
                        {
                            var dele = db.InvoiceDetails.Find(delete.Id);
                            db.InvoiceDetails.Remove(dele);
                            await db.SaveChangesAsync();
                        }
                    }
                    db.SaveChanges();
                }
                this.IsEnabled = true;
            }

            var dba = new QuanLyNongSanDBEntities();
            HD = dba.Invoices.Find(HD.Id);
            datagridgiohang.ItemsSource = HD.InvoiceDetails.ToList();

            stackpanelshow.Height = stackpaneledit.Height;
            this.Width = 800;
            stackpaneledit.Height = 0;
            btedit.Content = "Edit";
            btapply.IsEnabled = false;

            DataContext = null;
            DataContext = HD;  
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = HD;
            datagridgiohang.ItemsSource = HD.InvoiceDetails.ToList();
            insert = new List<InvoiceDetail>();
            view = new List<InvoiceDetail>();
            delete = new List<InvoiceDetail>();
        }

        private void btdelete_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new QuanLyNongSanDBEntities())
            {
                this.IsEnabled = false;
                var creen = new ConfirmWindow($"Ban Co Chac Muon Xoa Hoa Don {HD.Id}");
                creen.ShowDialog();
                if (creen.DialogResult == true)
                {
                    foreach (var CT in HD.InvoiceDetails)
                    {
                        var dele = db.InvoiceDetails.Find(CT.Id);
                        db.InvoiceDetails.Remove(dele);
                        db.SaveChanges();
                    }

                    var itemdelete = db.Invoices.Find(HD.Id);
                    db.Invoices.Remove(itemdelete);
                    db.SaveChanges();
                    this.Close();
                }
                this.IsEnabled = true;
            }
        }
        private void LoadEdit()
        {
            tbtenkh.Text = HD.TenKH;
            tbdiachi.Text = HD.DiaChiKH;
            tbsdt.Text = HD.SDT;
            tblngaydat.Text = HD.NgayTao;
            LoadStatus();
            tbltongtienhoadon.Text = HD.TongTien.ToString();
            datagridsp.ItemsSource = listSP.ToList();
            CopyList();
            datagridgihang.ItemsSource = view.ToList();
        }

        private void tbSL_TextChanged(object sender, TextChangedEventArgs e)
        {
            InvoiceDetail detail = datagridgihang.SelectedItem as InvoiceDetail;
            if (detail != null)
            {
                detail.TinhTongGia();
                double Tongtien = 0;
                foreach (var CT in view)
                {
                    Tongtien = Tongtien + CT.TongTien.Value;
                }
                tbltongtienhoadon.Text = Tongtien.ToString();
            }
        }
        private void CopyList()
        {
            insert.Clear();
            delete.Clear();
            view.Clear();
            foreach(var CT in HD.InvoiceDetails)
            {
                InvoiceDetail newCT = new InvoiceDetail()
                {
                    Id = CT.Id,
                    GiaBan = float.Parse(CT.GiaBan.ToString()),
                    IdInvoice = CT.IdInvoice.Value,
                    IdProduct = CT.IdProduct.Value,
                    SoLuong = CT.SoLuong,
                    TongTien = CT.TongTien
                };
                view.Add(CT);
            }
        }

        private void addproduct_Click(object sender, RoutedEventArgs e)
        {
            Product prd = datagridsp.SelectedItem as Product;
            bool flag = false;
            foreach (var item in view)
            {
                if (item.IdProduct == prd.Id)
                {
                    item.SoLuong++;
                    item.TinhTongGia();
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                InvoiceDetail newCT = new InvoiceDetail()
                {
                    IdProduct = prd.Id,
                    SoLuong = 1,
                    GiaBan = float.Parse(prd.Gia.ToString()),
                };
                newCT.TinhTongGia();
                view.Add(newCT);
                insert.Add(newCT);
            }
            double Tongtien = 0;
            foreach (var CT in view)
            {
                Tongtien = Tongtien + CT.TongTien.Value;
            }
            tbltongtienhoadon.Text = Tongtien.ToString();
            datagridgihang.ItemsSource = view.ToList();
        }

        private void btndeleteCT_Click(object sender, RoutedEventArgs e)
        {
            InvoiceDetail ct = datagridgihang.SelectedItem as InvoiceDetail;
            view.RemoveAt(view.IndexOf(ct));
            if(insert.IndexOf(ct) >= 0)
            {
                insert.RemoveAt(insert.IndexOf(ct));
            }
            else
            {
                delete.Add(ct);
            }
            double Tongtien = 0;
            foreach (var CT in view)
            {
                Tongtien = Tongtien + CT.TongTien.Value;
            }
            tbltongtienhoadon.Text = Tongtien.ToString();
            datagridgihang.ItemsSource = view.ToList();
        }
        private void LoadStatus()
        {
            if (HD.IdStatus == 1)
                rbtnchuagiao.IsChecked = true;
            else if (HD.IdStatus == 2)
                rbtndagiao.IsChecked = true;
            else if (HD.IdStatus == 3)
                rbtndahuy.IsChecked = true;
        }
        private void UpdateStatus(Invoice invoice)
        {
            if (rbtnchuagiao.IsChecked == true)
                invoice.IdStatus = 1;
            else if (rbtndagiao.IsChecked == true)
                invoice.IdStatus = 2;
            else if (rbtndahuy.IsChecked == true)
                invoice.IdStatus = 3;
        }
    }
}
