using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace npcGenerator.Model
{
	public class Encounter : INotifyPropertyChanged
	{
		private string currentEncounter;
		private string nextEncounter;
		private int maxEncChanse;

		private static List<string> CityEncounterPool = new List<string>();
		private static List<string> RoadEncounterPool = new List<string>();
		private static List<string> WildernessEncounterPool = new List<string>();
		private static List<string> TavernEncounterPool = new List<string>();

		// TODO: Нормальная логика генерации
		public Encounter(int maxChanse)
		{
			Random rnd = new Random();
			maxEncChanse = maxChanse;

			var choise = rnd.Next(0, 100);

			if (choise < maxEncChanse)
				currentEncounter = CityEncounterPool.ElementAt(rnd.Next(0, CityEncounterPool.Count())); // TODO: Смена типа энкаунтера
			else
				if (choise > maxEncChanse && choise < maxEncChanse + 25)
				currentEncounter = "Бой";
			else
				currentEncounter = "Ничего";
		}

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
			CityEncounterPool = Upload("CityEncounter", CityEncounterPool);
			RoadEncounterPool = Upload("RoadEncounter", RoadEncounterPool);
			WildernessEncounterPool = Upload("WildernessEncounter", WildernessEncounterPool);
			TavernEncounterPool = Upload("TavernEncounter", TavernEncounterPool);
		}

		public int MaxEncChanse
		{
			get { return maxEncChanse; }
			set
			{
				maxEncChanse = value;
				OnPropertyChanged("MaxEncChanse");
			}
		}

		public string CurrentEncounter
		{
			get { return currentEncounter; }
			set
			{
				currentEncounter = value;
				OnPropertyChanged("CurrentEncounter");
			}
		}

		public string NextEncounter
		{
			get { return nextEncounter; }
			set
			{
				nextEncounter = value;
				OnPropertyChanged("NextEncounter");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
