using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace PrivazkaIkomandyINotifyKomand
{
    public class NotebookVM : INotifyPropertyChanged
    {
        private Person selectedPerson;
        public ObservableCollection<Person> Entries { get; set; } = new ObservableCollection<Person>();

        private string newFIO = "ФИО";
        private string newAddress = "Адрес";
        private string newPhone = "Номер";

        public string NewFIO
        {
            get => newFIO;
            set
            {
                if (newFIO != value)
                {
                    newFIO = value;
                    OnPropertyChanged(nameof(NewFIO));
                }
            }
        }

        public string NewAddress
        {
            get => newAddress;
            set
            {
                if (newAddress != value)
                {
                    newAddress = value;
                    OnPropertyChanged(nameof(NewAddress));
                }
            }
        }

        public string NewPhone
        {
            get => newPhone;
            set
            {
                if (newPhone != value)
                {
                    newPhone = value;
                    OnPropertyChanged(nameof(NewPhone));
                }
            }
        }

        public Person SelectedPerson
        {
            get => selectedPerson;
            set
            {
                if (selectedPerson != value)
                {
                    selectedPerson = value;
                    OnPropertyChanged(nameof(SelectedPerson));
                }
            }
        }

        public NotebookVM() { }

        // Добавить
        public void AddEntry()
        {
            try
            {
                var np = new Person { FIO = NewFIO, Address = NewAddress, Phone = NewPhone };
                Entries.Add(np);
                SelectedPerson = np;

                // Сброс полей ввода
                NewFIO = "ФИО";
                NewAddress = "Адрес";
                NewPhone = "Номер";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблема добавления: " + ex.Message);
            }
        }

        // Удалить выбранный
        public void RemoveSelected()
        {
            try
            {
                if (SelectedPerson != null)
                {
                    Entries.Remove(SelectedPerson);
                    SelectedPerson = Entries.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблема удаления: " + ex.Message);
            }
        }

        // Обновить выбранный
        public void UpdateSelected()
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
                MessageBox.Show("Проблема изменения: " + ex.Message);
            }
        }

        // Сохранить всех в файл
        public void SaveAllToFile(string filePath)
        {
            try
            {
                using (var w = new StreamWriter(filePath))
                {
                    foreach (var p in Entries)
                    {
                        w.WriteLine($"{p.FIO};{p.Address};{p.Phone}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблема сохранения: " + ex.Message);
            }
        }

        // Загрузить из файла
        public void LoadAllFromFile(string filePath)
        {
            try
            {
                Entries.Clear();
                using (var r = new StreamReader(filePath))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        var parts = line.Split(';');
                        if (parts.Length >= 3)
                            Entries.Add(new Person { FIO = parts[0], Address = parts[1], Phone = parts[2] });
                    }
                }
                SelectedPerson = Entries.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблема загрузки: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nm)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nm));
        }
    }
}
