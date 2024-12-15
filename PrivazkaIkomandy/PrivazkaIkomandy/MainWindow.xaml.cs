using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrivazkaIkomandy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Добавить запись
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = DataContext as NotebookVM;
                vm?.AddPerson();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        // Удалить выбранного
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = DataContext as NotebookVM;
                vm?.RemoveSelectedPerson();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
        }

        // Изменить выбранного
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = DataContext as NotebookVM;
                if (vm?.SelectedPerson != null)
                {
                    vm.ModifySelectedPerson();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка изменения: " + ex.Message);
            }
        }

        // Сохранить в файл
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = DataContext as NotebookVM;
                if (vm != null)
                {
                    var sfd = new SaveFileDialog { Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*" };
                    if (true == sfd.ShowDialog())
                    {
                        vm.SaveToFile(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        // Загрузить из файла
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = DataContext as NotebookVM;
                if (vm != null)
                {
                    var ofd = new OpenFileDialog { Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*" };
                    if (true == ofd.ShowDialog())
                    {
                        vm.LoadFromFile(ofd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        // При фокусе очистка
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                switch (tb.Text)
                {
                    case "ФИО":
                    case "Адрес":
                    case "Телефон":
                        tb.Clear();
                        break;
                }
            }
        }
    }
}