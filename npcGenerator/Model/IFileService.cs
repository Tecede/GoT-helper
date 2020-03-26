using System.Collections.Generic;

namespace npcGenerator.Model
{
    public interface IFileService
    {
        List<Phone> Open(string filename);
        void Save(string filename, List<Phone> phoneList);
    }
}
