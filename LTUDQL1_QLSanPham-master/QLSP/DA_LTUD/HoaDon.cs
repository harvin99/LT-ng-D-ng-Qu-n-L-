using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_LTUD
{
    public class HoaDon : INotifyPropertyChanged
    {
        private int _ma;
        private string _sdt;
        private string _tenkh;
        private string _diachikh;
        private string _ngayDat;
        private float _tongtien;
        private int _tinhTrang;
        private List<ChitietHD> _cTHD;

        public int Ma
        {
            get
            {
                return _ma;
            }

            set
            {
                _ma = value;
            }
        }

        public string NgayDat
        {
            get
            {
                return _ngayDat;
            }

            set
            {
                _ngayDat = value;
            }
        }

        public int TinhTrang
        {
            get
            {
                return _tinhTrang;
            }

            set
            {
                _tinhTrang = value;
            }
        }

        public float Tongtien
        {
            get
            {
                return _tongtien;
            }

            set
            {
                _tongtien = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Tongtien"));
                }
            }
        }

        internal List<ChitietHD> CTHD
        {
            get
            {
                return _cTHD;
            }

            set
            {
                _cTHD = value;
            }
        }

        public string Sdt
        {
            get
            {
                return _sdt;
            }

            set
            {
                _sdt = value;
            }
        }

        public string Tenkh
        {
            get
            {
                return _tenkh;
            }

            set
            {
                _tenkh = value;
            }
        }

        public string Diachikh
        {
            get
            {
                return _diachikh;
            }

            set
            {
                _diachikh = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
