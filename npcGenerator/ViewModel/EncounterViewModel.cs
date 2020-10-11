using npcGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace npcGenerator.ViewModel
{
	class EncounterViewModel : INotifyPropertyChanged
	{
        public EncounterViewModel()
        {
            Encounter.StartUpload();
        }

        private int encounterChanse;
        public int EncounterChanse
        {
            get { return encounterChanse; }
            set
            {
                encounterChanse = value;
                OnPropertyChanged("EncounterChanse");
            }
        }

        private Encounter selectedEncounter;
        public Encounter SelectedEncounter
        {
            get { return selectedEncounter; }
            set
            {
                selectedEncounter = value;
                OnPropertyChanged("SelectedEncounter");
            }
        }

        private RelayCommand genCityEncCommand;
        public RelayCommand GenCityEncCommand
        {
            get
            {
                return genCityEncCommand ??
                  (genCityEncCommand = new RelayCommand(obj =>
                  {
                      Encounter encounter = new Encounter(encounterChanse);
                      selectedEncounter = encounter;
                  }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
