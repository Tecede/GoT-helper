using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace npcGenerator.Model
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        Character selectedCharacter;

        IFileService fileService;
        IDialogService dialogService;

        // Коллекция, уведомляющая при изменении
        public ObservableCollection<Character> Characters { get; set; }

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

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            Characters = new ObservableCollection<Character>
            {
                new Character {Feature = "Feat1", Ideal = "Ideal1", Attachment = "Att1", Weakness = "Weak1" },
                new Character {Feature = "Feat2", Ideal = "Ideal2", Attachment = "Att2", Weakness = "Weak2" },
                new Character {Feature = "Feat3", Ideal = "Ideal3", Attachment = "Att3", Weakness = "Weak3" },
                new Character {Feature = "Feat4", Ideal = "Ideal4", Attachment = "Att4", Weakness = "Weak4" },
            };
        }

        // Метод, обрабатывающий событие PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") // Получает имя метода, вызывающего этот метод
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop)); // Получает имя измененного свойства
        }
    }
}