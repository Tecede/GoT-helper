using System.Collections.Generic;
using System.IO;

namespace npcGenerator.Helpers
{
	public static class CharacterHelper
	{
		public static List<string> ProfessionPool = new List<string>();
		public static List<string> AlignmentPool = new List<string>();
		public static List<string> RichnessPool = new List<string>();
		public static List<string> SignPool = new List<string>();
		public static List<string> HairPool = new List<string>();
		public static List<string> HairColorPool = new List<string>();
		public static List<string> BeardPool = new List<string>();
		public static List<string> EyeColorPool = new List<string>();
		public static List<string> ClothPool = new List<string>();
		public static List<string> InteractionPool = new List<string>();
		public static List<string> MannersPool = new List<string>();
		public static List<string> QuestPool = new List<string>();
		public static List<string> NamePool = new List<string>();
		public static List<string> SurnamePool = new List<string>();
		public static List<string> FeaturePool = new List<string>();
		public static List<string> AttachmentPool = new List<string>();
		public static List<string> IdealPool = new List<string>();
		public static List<string> WeaknessPool = new List<string>();

		public static void Startup()
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
			SurnamePool = Upload("Surname", SurnamePool);
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
	}
}
