using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PrivazkaIkomandyINotifyKomand
{
    public class Person : INotifyPropertyChanged
    {
        private string fio;
        private string address;
        private string phone;

        public string FIO
        {
            get => fio;
            set
            {
                if (fio != value)
                {
                    fio = value;
                    OnPropertyChanged(nameof(FIO));
                }
            }
        }

        public string Address
        {
            get => address;
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public string Phone
        {
            get => phone;
            set
            {
                if (phone != value)
                {
                    phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
