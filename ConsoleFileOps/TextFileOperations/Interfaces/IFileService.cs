 using System.Collections.Generic;

namespace PersonDataFileOperations
{
    public interface IFileService
    {
        bool FileExist(string filePath);

        string FileData(string filePath);

        bool SaveFile(PersonData person, string filePath);

        List<PersonData> ReadFile(string filePath);
    }
}