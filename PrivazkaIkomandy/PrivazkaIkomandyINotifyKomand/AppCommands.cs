using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrivazkaIkomandyINotifyKomand
{
    public static class AppCommands
    {
        public static RoutedUICommand AddItem { get; } = new RoutedUICommand(
            "Добавить", "AddItem", typeof(AppCommands),
            new InputGestureCollection { new KeyGesture(Key.N, ModifierKeys.Control) });

        public static RoutedUICommand RemoveItem { get; } = new RoutedUICommand(
            "Удалить", "RemoveItem", typeof(AppCommands),
            new InputGestureCollection { new KeyGesture(Key.Delete) });

        public static RoutedUICommand UpdateItem { get; } = new RoutedUICommand(
            "Изменить", "UpdateItem", typeof(AppCommands),
            new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Control) });

        public static RoutedUICommand SaveAll { get; } = new RoutedUICommand(
            "Сохранить", "SaveAll", typeof(AppCommands),
            new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Control) });

        public static RoutedUICommand LoadAll { get; } = new RoutedUICommand(
            "Загрузить", "LoadAll", typeof(AppCommands),
            new InputGestureCollection { new KeyGesture(Key.O, ModifierKeys.Control) });
    }
}
