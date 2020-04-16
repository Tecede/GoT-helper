using Newtonsoft.Json;
using npcGenerator.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace npcGenerator.ViewModel
{
    class LordsViewModel : INotifyPropertyChanged
    {
        private IDialogService dialogService;
        private IFileService fileService;
        public ObservableCollection<Character> Characters { get; set; }

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

        public LordsViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            Characters = new ObservableCollection<Character>();

            Character.StartUpload();

            //UploadLords();
        }

        // команда сохранения файла
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      //try
                      //{
                      //    if (dialogService.SaveFileDialog() == true)
                      //    {
                      //        fileService.Save("../../Data/Saves/Lords.txt", Characters.ToList());
                      //        dialogService.ShowMessage("Файл сохранен");
                      //    }
                      //}
                      //catch (Exception ex)
                      //{
                      //    dialogService.ShowMessage(ex.Message);
                      //}
                  }));
            }
        }

        private async void UploadLords()
        {
            //await Task.Factory.StartNew(() =>
            //{
            //    try
            //    {
            //        using (FileStream fs = File.Open("../../Data/Saves/Lords.txt", FileMode.Open))
            //        {
            //            var p = formatter.Deserialize(fs);
            //        }
            //        var characters = fileService.Open();
            //        //Characters.Clear();
            //        foreach (var p in characters)
            //            Characters.Add(p);
            //    }
            //    catch (Exception ex)
            //    {
            //        dialogService.ShowMessage(ex.Message);
            //    }
            //});
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
