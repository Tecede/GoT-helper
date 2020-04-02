using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace npcGenerator.Model
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
       

        // Метод, обрабатывающий событие PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") // Получает имя метода, вызывающего этот метод
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop)); // Получает имя измененного свойства
        }
    }
}