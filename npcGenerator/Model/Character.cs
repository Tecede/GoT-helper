using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace npcGenerator.Model
{
	public class Character : INotifyPropertyChanged
	{
		public int Id { get; set; }

		private string name; // TODO: Генерация имен по расам и полу
		private string feature;
		private string attachment;
		private string ideal;
		private string weakness;
		private int age;
		private string gender;
		private string clan;
		private string knowledge;
		private string race;
		private string heroImgPath;
		private string family;
		private string profession;
		private string alignment;
		private string richness;
		private string sign;
		private string hair;
		private string hairColor;
		private string beard;
		private string eyeColor;
		private string cloth;
		private string interaction;
		private string manners;
		private string quest;

		private static List<string> FamilyPool = new List<string>();
		private static List<string> ProfessionPool = new List<string>();
		private static List<string> AlignmentPool = new List<string>();
		private static List<string> RichnessPool = new List<string>();
		private static List<string> SignPool = new List<string>();
		private static List<string> HairPool = new List<string>();
		private static List<string> HairColorPool = new List<string>();
		private static List<string> BeardPool = new List<string>();
		private static List<string> EyeColorPool = new List<string>();
		private static List<string> ClothPool = new List<string>();
		private static List<string> InteractionPool = new List<string>();
		private static List<string> MannersPool = new List<string>();
		private static List<string> QuestPool = new List<string>();
		private static List<string> NamePool = new List<string>();
		private static List<string> SurnamePool = new List<string>();
		private static List<string> FeaturePool = new List<string>();
		private static List<string> AttachmentPool = new List<string>();
		private static List<string> IdealPool = new List<string>();
		private static List<string> WeaknessPool = new List<string>();

		// TODO: Async
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
			QuestPool = Upload("Quest", QuestPool);
			MannersPool = Upload("Manners", MannersPool);
			InteractionPool = Upload("Interaction", InteractionPool);
			ClothPool = Upload("Cloth", ClothPool);
			EyeColorPool = Upload("EyeColor", EyeColorPool);
			BeardPool = Upload("Beard", BeardPool);
			HairColorPool = Upload("HairColor", HairColorPool);
			HairPool = Upload("Hair", HairPool);
			SignPool = Upload("Sign", SignPool);
			RichnessPool = Upload("Richness", RichnessPool);
			AlignmentPool = Upload("Alignment", AlignmentPool);
			ProfessionPool = Upload("Profession", ProfessionPool);
			FeaturePool = Upload("Feature", FeaturePool);
			AttachmentPool = Upload("Attachment", AttachmentPool);
			IdealPool = Upload("Ideal", IdealPool);
			WeaknessPool = Upload("weakness", WeaknessPool);
			NamePool = Upload("Name", NamePool);
			FamilyPool = Upload("Family", FamilyPool);
		}

		public Character()
		{
			Random rnd = new Random();

			feature = FeaturePool.ElementAt(rnd.Next(0, FeaturePool.Count()));
			attachment = AttachmentPool.ElementAt(rnd.Next(0, AttachmentPool.Count()));
			ideal = IdealPool.ElementAt(rnd.Next(0, IdealPool.Count()));
			weakness = WeaknessPool.ElementAt(rnd.Next(0, WeaknessPool.Count()));
			name = NamePool.ElementAt(rnd.Next(0, NamePool.Count()));
			quest = QuestPool.ElementAt(rnd.Next(0, QuestPool.Count()));
			manners = MannersPool.ElementAt(rnd.Next(0, MannersPool.Count()));
			interaction = InteractionPool.ElementAt(rnd.Next(0, InteractionPool.Count()));
			cloth = ClothPool.ElementAt(rnd.Next(0, ClothPool.Count()));
			eyeColor = EyeColorPool.ElementAt(rnd.Next(0, EyeColorPool.Count()));
			beard = BeardPool.ElementAt(rnd.Next(0, BeardPool.Count()));
			hairColor = HairColorPool.ElementAt(rnd.Next(0, HairColorPool.Count()));
			hair = HairPool.ElementAt(rnd.Next(0, HairPool.Count()));
			sign = SignPool.ElementAt(rnd.Next(0, SignPool.Count()));
			richness = RichnessPool.ElementAt(rnd.Next(0, RichnessPool.Count()));
			alignment = AlignmentPool.ElementAt(rnd.Next(0, AlignmentPool.Count()));
			profession = ProfessionPool.ElementAt(rnd.Next(0, ProfessionPool.Count()));

			age = rnd.Next(16, 59);

			if (rnd.Next(1, 5) <= 4)
				gender = "Мужчина";
			else
				gender = "Женщина";

			heroImgPath = "../../Data/HeroImg.jpg";
		}

		public string Family
		{
			get { return family; }
			set
			{
				family = value;
				OnPropertyChanged("Family");
			}
		}

		public string Profession
		{
			get { return profession; }
			set
			{
				profession = value;
				OnPropertyChanged("Profession");
			}
		}

		public string Alignment
		{
			get { return alignment; }
			set
			{
				alignment = value;
				OnPropertyChanged("Alignment");
			}
		}

		public string Richness
		{
			get { return richness; }
			set
			{
				richness = value;
				OnPropertyChanged("Richness");
			}
		}

		public string Race
		{
			get { return race; }
			set
			{
				race = value;
				OnPropertyChanged("Race");
			}
		}

		public string Sign
		{
			get { return sign; }
			set
			{
				sign = value;
				OnPropertyChanged("Sign");
			}
		}

		public string Hair
		{
			get { return hair; }
			set
			{
				hair = value;
				OnPropertyChanged("Hair");
			}
		}

		public string Beard
		{
			get { return beard; }
			set
			{
				beard = value;
				OnPropertyChanged("Beard");
			}
		}

		public string HairColor
		{
			get { return hairColor; }
			set
			{
				hairColor = value;
				OnPropertyChanged("HairColor");
			}
		}

		public string EyeColor
		{
			get { return eyeColor; }
			set
			{
				eyeColor = value;
				OnPropertyChanged("EyeColor");
			}
		}

		public string Cloth
		{
			get { return cloth; }
			set
			{
				cloth = value;
				OnPropertyChanged("Cloth");
			}
		}

		public string Interaction
		{
			get { return interaction; }
			set
			{
				interaction = value;
				OnPropertyChanged("Interaction");
			}
		}

		public string Knowledge
		{
			get { return knowledge; }
			set
			{
				knowledge = value;
				OnPropertyChanged("Knowledge");
			}
		}

		public string Manners
		{
			get { return manners; }
			set
			{
				manners = value;
				OnPropertyChanged("Manners");
			}
		}

		public string Quest
		{
			get { return quest; }
			set
			{
				quest = value;
				OnPropertyChanged("Quest");
			}
		}

		public string Clan
		{
			get { return clan; }
			set
			{
				clan = value;
				OnPropertyChanged("Clan");
			}
		}

		public string HeroImgPath
		{
			get { return heroImgPath; }
			set
			{
				heroImgPath = value;
				OnPropertyChanged("HeroImgPath");
			}
		}

		public int Age
		{
			get { return age; }
			set
			{
				age = value;
				OnPropertyChanged("Age");
			}
		}

		public string Gender
		{
			get { return gender; }
			set
			{
				gender = value;
				OnPropertyChanged("Gender");
			}
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

		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
