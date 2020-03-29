using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace npcGenerator.Model
{
    public class Character : INotifyPropertyChanged
    {
        private string feature;
        private string attachment;
        private string ideal;
        private string weakness;

        public string Feature
        {
            get { return feature; }
            set
            {
                feature = value;
                OnPropertyChanged("Feature");
            }
        }

        public string Attachment
        {
            get { return attachment; }
            set
            {
                attachment = value;
                OnPropertyChanged("Attachment");
            }
        }

        public string Ideal
        {
            get { return ideal; }
            set
            {
                ideal = value;
                OnPropertyChanged("Ideal");
            }
        }

        public string Weakness
        {
            get { return weakness; }
            set
            {
                weakness = value;
                OnPropertyChanged("Weakness");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
