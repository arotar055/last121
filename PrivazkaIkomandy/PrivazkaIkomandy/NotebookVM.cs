using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace PrivazkaIkomandy
{
    internal class NotebookVM : System.Windows.DependencyObject
    {
        // Храним выбранного человека
        public static readonly System.Windows.DependencyProperty SelectedPersonProperty =
            System.Windows.DependencyProperty.Register(nameof(SelectedPerson), typeof(Person), typeof(NotebookVM), new System.Windows.PropertyMetadata(null));

        public Person SelectedPerson
        {
            get => (Person)GetValue(SelectedPersonProperty);
            set => SetValue(SelectedPersonProperty, value);
        }

        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();

        public static readonly System.Windows.DependencyProperty NewFIOProperty =
            System.Windows.DependencyProperty.Register(nameof(NewFIO), typeof(string), typeof(NotebookVM), new System.Windows.PropertyMetadata("ФИО"));
        public string NewFIO
        {
            get => (string)GetValue(NewFIOProperty);
            set => SetValue(NewFIOProperty, value);
        }

        public static readonly System.Windows.DependencyProperty NewAddressProperty =
            System.Windows.DependencyProperty.Register(nameof(NewAddress), typeof(string), typeof(NotebookVM), new System.Windows.PropertyMetadata("Адрес"));
        public string NewAddress
        {
            get => (string)GetValue(NewAddressProperty);
            set => SetValue(NewAddressProperty, value);
        }

        public static readonly System.Windows.DependencyProperty NewPhoneProperty =
            System.Windows.DependencyProperty.Register(nameof(NewPhone), typeof(string), typeof(NotebookVM), new System.Windows.PropertyMetadata("Телефон"));
        public string NewPhone
        {
            get => (string)GetValue(NewPhoneProperty);
            set => SetValue(NewPhoneProperty, value);
        }

        public NotebookVM() { }

        // Добавление записи
        public void AddPerson()
        {
            try
            {
                var p = new Person { FIO = NewFIO, Address = NewAddress, Phone = NewPhone };
                People.Add(p);
                SelectedPerson = p;
                // Сброс ввода
                NewFIO = "ФИО"; NewAddress = "Адрес"; NewPhone = "Телефон";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }

        // Изменение
        public void ModifySelectedPerson()
        {
            try
            {
                if (SelectedPerson != null)
                {
                    SelectedPerson.FIO = NewFIO;
                    SelectedPerson.Address = NewAddress;
                    SelectedPerson.Phone = NewPhone;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении: " + ex.Message);
            }
        }

        // Удаление
        public void RemoveSelectedPerson()
        {
            try
            {
                if (SelectedPerson != null && People.Contains(SelectedPerson))
                {
                    People.Remove(SelectedPerson);
                    SelectedPerson = People.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message);
            }
        }

        // Сохранение
        public void SaveToFile(string filePath)
        {
            try
            {
                using (var w = new StreamWriter(filePath))
                {
                    foreach (var pp in People)
                    {
                        w.WriteLine(pp.FIO + ";" + pp.Address + ";" + pp.Phone);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
        }

        // Загрузка
        public void LoadFromFile(string filePath)
        {
            try
            {
                People.Clear();
                using (var r = new StreamReader(filePath))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        var parts = line.Split(';');
                        if (parts.Length >= 3)
                        {
                            People.Add(new Person { FIO = parts[0], Address = parts[1], Phone = parts[2] });
                        }
                    }
                }
                SelectedPerson = People.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке: " + ex.Message);
            }
        }
    }
}
