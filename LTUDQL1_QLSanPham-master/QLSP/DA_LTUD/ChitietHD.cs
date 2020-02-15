using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_LTUD
{
    class ChitietHD : INotifyPropertyChanged
    {
        private int _ma;
        private int _mahd;
        private int _masp;
        private float _gia;
        private int _soluong;
        private float _tonggia;

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

        public int Mahd
        {
            get
            {
                return _mahd;
            }

            set
            {
                _mahd = value;
            }
        }

        public int Masp
        {
            get
            {
                return _masp;
            }

            set
            {
                _masp = value;
            }
        }

        public float Gia
        {
            get
            {
                return _gia;
            }

            set
            {
                _gia = value;
            }
        }

        public int Soluong
        {
            get
            {
                return _soluong;
            }

            set
            {
                _soluong = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Soluong"));
                }
            }
        }

        public float Tonggia
        {
            get
            {
                return _tonggia;
            }

            set
            {
                _tonggia = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Tonggia"));
                }
            }
        }
        public void TinhTongGia()
        {
            Tonggia = Gia * Soluong;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
