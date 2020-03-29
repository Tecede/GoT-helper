using System.Collections.Generic;

namespace npcGenerator.Model
{
    public interface IFileService
    {
        List<Character> Open(string filename);
        void Save(string filename, List<Character> characterList);
    }
}
