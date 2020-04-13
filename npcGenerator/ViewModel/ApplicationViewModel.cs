using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Threading;

namespace npcGenerator.Model
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        Character selectedCharacter;

        // TODO: Вынести в модель
        private Page Main;
        private Page Exit;
        private Page Test;

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

        // Коллекция, уведомляющая при изменении
        public ObservableCollection<Character> Characters { get; set; }

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            Main = new View.Main();
            Test = new View.Test();
            Exit = new View.Exit();

            FrameOpacity = 1;
            CurrentPage = Main;

            Character.StartUpload();

            Characters = new ObservableCollection<Character>
            {
                new Character(),
                new Character(),
                new Character(),
                new Character()
            };
        }

        private RelayCommand testClick;
        public RelayCommand TestClick
        {
            get
            {
                return testClick ??
                    (testClick = new RelayCommand(obj=>
                    {
                        SlowOpacity(Test);
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

        // команда сохранения файла
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ?? // Возвращает лево, если не NULL, иначе право
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, Characters.ToList());
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда открытия файла
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var characters = fileService.Open(dialogService.FilePath);
                              Characters.Clear();
                              foreach (var p in characters)
                                  Characters.Add(p);
                              dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Character character = new Character();
                      Characters.Insert(0, character);
                      selectedCharacter = character;
                  }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Character character = obj as Character;
                      if (character != null)
                      {
                          Characters.Remove(character);
                      }
                  },
                 (obj) => Characters.Count > 0));
            }
        }
        private RelayCommand doubleCommand;
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??
                  (doubleCommand = new RelayCommand(obj =>
                  {
                      Character character = obj as Character;
                      if (character != null)
                      {
                          Character characterCopy = new Character
                          {
                              Feature = character.Feature,
                              Attachment = character.Attachment,
                              Ideal = character.Ideal,
                              Weakness = character.Weakness
                          };
                          Characters.Insert(0, characterCopy);
                      }
                  }));
            }
        }

        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set
            {
                selectedCharacter = value;
                OnPropertyChanged("SelectedCharacter");
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