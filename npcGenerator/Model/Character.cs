using npcGenerator.Helpers;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace npcGenerator.Model
{
	public class Character : INotifyPropertyChanged
	{
		public int Id { get; set; }
		private string name;
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

		public Character()
		{
			Random rnd = new Random();

			feature = CharacterHelper.FeaturePool.ElementAt(rnd.Next(0, CharacterHelper.FeaturePool.Count()));
			attachment = CharacterHelper.AttachmentPool.ElementAt(rnd.Next(0, CharacterHelper.AttachmentPool.Count()));
			ideal = CharacterHelper.IdealPool.ElementAt(rnd.Next(0, CharacterHelper.IdealPool.Count()));
			weakness = CharacterHelper.WeaknessPool.ElementAt(rnd.Next(0, CharacterHelper.WeaknessPool.Count()));
			name = CharacterHelper.NamePool.ElementAt(rnd.Next(0, CharacterHelper.NamePool.Count()));
			//family = FamilyPool.ElementAt(rnd.Next(0, FamilyPool.Count()));
			quest = CharacterHelper.QuestPool.ElementAt(rnd.Next(0, CharacterHelper.QuestPool.Count()));
			manners = CharacterHelper.MannersPool.ElementAt(rnd.Next(0, CharacterHelper.MannersPool.Count()));
			interaction = CharacterHelper.InteractionPool.ElementAt(rnd.Next(0, CharacterHelper.InteractionPool.Count()));
			cloth = CharacterHelper.ClothPool.ElementAt(rnd.Next(0, CharacterHelper.ClothPool.Count()));
			eyeColor = CharacterHelper.EyeColorPool.ElementAt(rnd.Next(0, CharacterHelper.EyeColorPool.Count()));
			beard = CharacterHelper.BeardPool.ElementAt(rnd.Next(0, CharacterHelper.BeardPool.Count()));
			hairColor = CharacterHelper.HairColorPool.ElementAt(rnd.Next(0, CharacterHelper.HairColorPool.Count()));
			hair = CharacterHelper.HairPool.ElementAt(rnd.Next(0, CharacterHelper.HairPool.Count()));
			sign = CharacterHelper.SignPool.ElementAt(rnd.Next(0, CharacterHelper.SignPool.Count()));
			richness = CharacterHelper.RichnessPool.ElementAt(rnd.Next(0, CharacterHelper.RichnessPool.Count()));
			alignment = CharacterHelper.AlignmentPool.ElementAt(rnd.Next(0, CharacterHelper.AlignmentPool.Count()));
			profession = CharacterHelper.ProfessionPool.ElementAt(rnd.Next(0, CharacterHelper.ProfessionPool.Count()));

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
