using npcGenerator.Helpers;
using npcGenerator.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace npcGenerator.ViewModel
{
    class LordsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Character> Characters { get; set; }

        public LordsViewModel()
        {
            Characters = new ObservableCollection<Character>();

            CharacterHelper.Startup();
            //UploadLords();
        }

        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set
            {
                selectedCharacter = value;
                OnPropertyChanged("SelectedCharacter");
            }
        }

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
                      SelectedCharacter = character;
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

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      using (CharacterContext context = new CharacterContext())
                      {
                          foreach (var ch in Characters)
                          {
                              context.Characters.Add(ch);
                          }

                          context.SaveChanges();
                      }
                  }));
            }
        }

        // TODO: Async?
        private void UploadLords()
        {
            using (CharacterContext context = new CharacterContext())
            {
                var chList = context.Characters.ToList();

                // Неявное преобразование List to ObservableCollection
                foreach (var ch in chList)
                {
                    Characters.Add(ch);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
