using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Threading;
using npcGenerator.View;

namespace npcGenerator.Model
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Page Main;
        private Page Lords;
        private Page Encounters;


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

        public ApplicationViewModel()
        { 
            Main = new Main();
            Lords = new Lords();
            Encounters = new Encounters();

            FrameOpacity = 1;
            CurrentPage = Main;
        }

        private RelayCommand lordsClick;
        public RelayCommand LordsClick
        {
            get
            {
                return lordsClick ??
                    (lordsClick = new RelayCommand(obj=>
                    {
                        SlowOpacity(Lords);
                    }));
            }
        }

        private RelayCommand mainClick;
        public RelayCommand MainClick
        {
            get
            {
                return mainClick ??
                    (mainClick = new RelayCommand(obj =>
                    {
                        SlowOpacity(Main);
                    }));
            }
        }

        private RelayCommand encounterClick;
        public RelayCommand EncounterClick
        {
            get
            {
                return encounterClick ??
                    (encounterClick = new RelayCommand(obj =>
                    {
                        SlowOpacity(Encounters);
                    }));
            }
        }

        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for(double i = 1.0; i > 0.0; i-= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = page;

                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }

        // Метод, обрабатывающий событие PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") // Получает имя метода, вызывающего этот метод
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop)); // Получает имя измененного свойства
        }
    }
}