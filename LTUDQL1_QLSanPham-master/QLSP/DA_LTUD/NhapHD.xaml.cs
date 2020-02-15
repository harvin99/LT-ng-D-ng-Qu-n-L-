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
    /// Interaction logic for NhapHD.xaml
    /// </summary>
    public partial class NhapHD : Window
    {
        List<Product> listproduct;
        List<HoaDon> listhd;
        List<InvoiceDetail> listcthd;
        public NhapHD(List<Product> listpd, List<HoaDon> listhoadon)
        {
            listhd = listhoadon;
            listproduct = listpd;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private async void btadd_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new QuanLyNongSanDBEntities())
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
                else if(tbsdt.Text == "")
                {
                    MessageBox.Show("SĐT Khách Hàng Không Được Trống");
                    return;
                }   
                else if (tblngaydat.Text == "")
                {
                    MessageBox.Show("Ngay Đạt Không Được Trống");
                    return;
                }    
                else if (listcthd.Count == 0)
                {
                    MessageBox.Show("Hóa Đơn Phải Có Ít Nhất 1 SP");
                    return;
                }
                    Invoice newHD = new Invoice()
                    {
                        TenKH = tbtenkh.Text,
                        DiaChiKH = tbdiachi.Text,
                        SDT = tbsdt.Text,
                        NgayTao = tblngaydat.Text,
                        NgayUpdate = tblngaydat.Text,
                        IdStatus = 1,
                        TongTien = float.Parse(tbltongtienhoadon.Text),
                    };
                    db.Invoices.Add(newHD);

                    await db.SaveChangesAsync();

                    foreach (var CT in listcthd)
                    {
                        InvoiceDetail newdetail = new InvoiceDetail()
                        {
                            IdInvoice = newHD.Id,
                            IdProduct = CT.IdProduct,
                            GiaBan = CT.GiaBan,
                            SoLuong = CT.SoLuong,
                            TongTien = CT.TongTien,
                        };
                        newHD.InvoiceDetails.Add(newdetail);
                        await db.SaveChangesAsync();
                    }
                
            }
            this.Close();
        }

        private void btcancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //tblngaydat.Text = System.DateTime.Now.ToString();
            datagridsp.ItemsSource = listproduct.ToList();
            tbltinhtrang.Text = "Chưa Giao";
            tbltongtienhoadon.Text = "0";
            listcthd = new List<InvoiceDetail>();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Product prd = datagridsp.SelectedItem as Product;
            bool flag = false;
            foreach (var item in listcthd)
            {
                if(item.IdProduct == prd.Id)
                {
                    item.SoLuong++;
                    item.TinhTongGia();
                    flag = true;
                    break;
                }
            }
            if(flag == false)
            {
                InvoiceDetail newCT = new InvoiceDetail()
                {
                    IdProduct = prd.Id,
                    SoLuong = 1,
                    GiaBan = float.Parse(prd.Gia.ToString()),
                };
                newCT.TinhTongGia();
                listcthd.Add(newCT);       
            }
            double Tongtien = 0;
            foreach (var CT in listcthd)
            {
                Tongtien = Tongtien + CT.TongTien.Value;
            }
            tbltongtienhoadon.Text = Tongtien.ToString();
            datagridgihang.ItemsSource = listcthd.ToList();
        }

        private void tbfilterproduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = tbfilterproduct.Text;
            var data = from product in listproduct
                       where product.Name.ToLower().AccentRemoved().Contains(keyword.ToLower())
                       select product;
            datagridsp.ItemsSource = data;
        }

        private void tbSL_TextChanged(object sender, TextChangedEventArgs e)
        {
            InvoiceDetail detail = datagridgihang.SelectedItem as InvoiceDetail;
            if (detail != null)
            {
                detail.TinhTongGia();
                double Tongtien = 0;
                foreach (var CT in listcthd)
                {
                    Tongtien = Tongtien + CT.TongTien.Value;
                }
                tbltongtienhoadon.Text = Tongtien.ToString();
            }
        }

        private void btndeleteCT_Click(object sender, RoutedEventArgs e)
        {
            InvoiceDetail detail = datagridgihang.SelectedItem as InvoiceDetail;
            listcthd.RemoveAt(listcthd.IndexOf(detail));
            datagridgihang.ItemsSource = listcthd.ToList();
        }
    }
}
