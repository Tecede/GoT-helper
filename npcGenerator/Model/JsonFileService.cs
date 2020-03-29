using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace npcGenerator.Model
{
    public class JsonFileService : IFileService
    {
        public List<Character> Open(string filename)
        {
            List<Character> characters = new List<Character>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Character>));

            using(FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                characters = jsonFormatter.ReadObject(fs) as List<Character>;
            }

            return characters;
        }

        public void Save(string filename, List<Character> characterList)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Character>));
            
            using(FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, characterList);
            }
        }
    }
}
