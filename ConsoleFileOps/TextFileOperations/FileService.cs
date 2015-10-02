using System.Collections.Generic;
using System.Linq;

namespace PersonDataFileOperations
{
    public class FileService : IFileService
    {
        private IFileRepository _fileOps;

        public FileService(IFileRepository fileOps)
        {
            _fileOps = fileOps;
        }

        public bool FileExist(string filePath)
        {
            return _fileOps.FileExist(filePath);
        }

        public string FileData(string filePath)
        {
            return _fileOps.FileData(filePath);
        }

        public bool SaveFile(PersonData person, string filePath)
        {
            return _fileOps.SaveFile(person, filePath);
        }

        //public List<PersonData> ReadFile(string filePath)
        //{
        //    PersonData person;
        //    var personList = new List<PersonData>();

        //    var fileContent = _fileOps.ReadFile(filePath);
        //    var fileContentArray = fileContent.Split('\n');

        //    for (int i = 0; i < fileContentArray.Length-1; i += 4)
        //    {
        //        person = new PersonData(fileContentArray[i].Replace("\r", ""), fileContentArray[i + 1].Replace("\r", ""), fileContentArray[i + 2].Replace("\r", ""),
        //            fileContentArray[i + 3].Replace("\r", ""));
        //        personList.Add(person);
        //    }
        //    return personList;
        //}

        public List<PersonData> ReadFile(string filePath)
        {
            //PersonData person;
            //ar personList = new List<PersonData>();

            var fileContent = _fileOps.ReadFile(filePath);
            

            return fileContent;
        }
    }
}