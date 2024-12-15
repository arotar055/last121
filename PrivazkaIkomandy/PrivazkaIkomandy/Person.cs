using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrivazkaIkomandy
{
    public class Person : DependencyObject
    {
        public static readonly DependencyProperty FIOProperty =
            DependencyProperty.Register(nameof(FIO), typeof(string), typeof(Person), new PropertyMetadata(string.Empty));
        public string FIO
        {
            get => (string)GetValue(FIOProperty);
            set => SetValue(FIOProperty, value);
        }

        public static readonly DependencyProperty AddressProperty =
            DependencyProperty.Register(nameof(Address), typeof(string), typeof(Person), new PropertyMetadata(string.Empty));
        public string Address
        {
            get => (string)GetValue(AddressProperty);
            set => SetValue(AddressProperty, value);
        }

        public static readonly DependencyProperty PhoneProperty =
            DependencyProperty.Register(nameof(Phone), typeof(string), typeof(Person), new PropertyMetadata(string.Empty));
        public string Phone
        {
            get => (string)GetValue(PhoneProperty);
            set => SetValue(PhoneProperty, value);
        }
    }
}
