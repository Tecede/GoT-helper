using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace npcGenerator.Model
{
    public class Character : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name; // TODO: Реализовать считывание и генерацию имен

        private string feature;
        private string attachment;
        private string ideal;
        private string weakness;

        private static List<string> NamePool = new List<string>();
        private static List<string> SurnamePool = new List<string>();
        private static List<string> FeaturePool = new List<string>();
        private static List<string> AttachmentPool = new List<string>();
        private static List<string> IdealPool = new List<string>();
        private static List<string> WeaknessPool = new List<string>();

        private static List<string> Upload(string path, List<string> feature)
        {
            using (StreamReader features = new StreamReader($"../../Data/{path}.txt"))
            {
                while (true)
                {
                    string temp = features.ReadLine();

                    if (temp == null)
                        break;
                    else
                        feature.Add(temp);
                }

                return feature;
            }
        }

        public static void StartUpload()
        {
           FeaturePool = Upload("Feature", FeaturePool);
           AttachmentPool = Upload("Attachment", AttachmentPool);
           IdealPool = Upload("Ideal", IdealPool);
           WeaknessPool = Upload("weakness", WeaknessPool);
        }

        public Character()
        {
            Random rnd = new Random();

            feature = FeaturePool.ElementAt(rnd.Next(0, FeaturePool.Count()));
            attachment = AttachmentPool.ElementAt(rnd.Next(0, AttachmentPool.Count()));
            ideal = IdealPool.ElementAt(rnd.Next(0, IdealPool.Count()));
            weakness = WeaknessPool.ElementAt(rnd.Next(0, WeaknessPool.Count()));
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

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
