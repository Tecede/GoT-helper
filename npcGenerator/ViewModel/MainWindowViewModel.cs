using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Controls;
using npcGenerator.View;
using System.Threading.Tasks;
using System.Threading;

namespace npcGenerator.Model
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Page welcome;
        private Page main;
        private Page exit;
        private Page test;

        // TODO: Вынести в Model
        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set 
            { 
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private double frameOpacity;
        public double FrameOpacity
        {
            get { return frameOpacity; }
            set
            {
                frameOpacity = value;
                OnPropertyChanged("FrameOpacity");
            }
        }

        IFileService fileService;
        IDialogService dialogService;

        public MainWindowViewModel()
        {
            welcome = new View.Welcome();
            main = new View.Main();
            exit = new View.Exit();
            test = new View.Test();

            FrameOpacity = 1;
            CurrentPage = welcome;
        }

        private RelayCommand bMenuMain_Click;
        public RelayCommand BMenuMain_Click
        {
            get
            {
                //return new RelayCommand(() => SlowOpacity(Main));
                return bMenuMain_Click ??
                    (bMenuMain_Click = new RelayCommand(obj => SlowOpacity(Test)));
            }
        }

        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i = +0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") // Получает имя метода, вызывающего этот метод
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop)); // Получает имя измененного свойства
        }
    }
}