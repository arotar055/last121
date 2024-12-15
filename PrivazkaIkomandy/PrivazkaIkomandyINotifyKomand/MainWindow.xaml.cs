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

namespace PrivazkaIkomandyINotifyKomand
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

            // Команда добавления
            private void AddItem_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                var vm = DataContext as NotebookVM;
                try
                {
                    vm?.AddEntry();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при добавлении: " + ex.Message);
                }
            }

            private void AddItem_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                var vm = DataContext as NotebookVM;
                e.CanExecute = vm != null && !string.IsNullOrWhiteSpace(vm.NewFIO) && vm.NewFIO != "ФИО";
            }

            // Команда удаления
            private void RemoveItem_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                var vm = DataContext as NotebookVM;
                try
                {
                    vm?.RemoveSelected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при удалении: " + ex.Message);
                }
            }

            private void RemoveItem_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                var vm = DataContext as NotebookVM;
                e.CanExecute = vm != null && vm.SelectedPerson != null;
            }

            // Команда изменения
            private void UpdateItem_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                var vm = DataContext as NotebookVM;
                try
                {
                    vm?.UpdateSelected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при изменении: " + ex.Message);
                }
            }

            private void UpdateItem_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                var vm = DataContext as NotebookVM;
                e.CanExecute = vm != null && vm.SelectedPerson != null;
            }

            // Команда сохранения
            private void SaveAll_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                var vm = DataContext as NotebookVM;
                try
                {
                    if (vm != null)
                    {
                        var sfd = new SaveFileDialog { Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*" };
                        if (true == sfd.ShowDialog())
                            vm.SaveAllToFile(sfd.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при сохранении: " + ex.Message);
                }
            }

            private void SaveAll_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                var vm = DataContext as NotebookVM;
                e.CanExecute = vm != null && vm.Entries.Any();
            }

            // Команда загрузки
            private void LoadAll_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                var vm = DataContext as NotebookVM;
                try
                {
                    if (vm != null)
                    {
                        var ofd = new OpenFileDialog { Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*" };
                        if (true == ofd.ShowDialog())
                            vm.LoadAllFromFile(ofd.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблема при загрузке: " + ex.Message);
                }
            }

            private void LoadAll_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = true;
            }

            // Очистка поля
            private void Field_GotFocus(object sender, RoutedEventArgs e)
            {
                if (sender is TextBox tb && (tb.Text == "ФИО" || tb.Text == "Адрес" || tb.Text == "Номер"))
                {
                    tb.Clear();
                }
            }
        }
    
}