using System.Collections.Generic;
using System.IO;
using System;

namespace PersonDataFileOperations
{
    public class TextFileSchedulingAccessToCPURepository : IFileRepository
    {
        private FileStream _fileStream;
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private List<PersonData> _fileContentList;

        public bool FileExist(string filePath)
        {
            return FileRepositoryHelper.FileExist(filePath);
        }

        public string FileData(string filePath)
        {
            return FileRepositoryHelper.FileData(filePath);
        }

        public bool SaveFile(PersonData person, string filePath)
        {
            _fileStream = !File.Exists(filePath)
                ? new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                : new FileStream(filePath, FileMode.Append, FileAccess.Write);

            try
            {
                _streamWriter = new StreamWriter(_fileStream);
                _streamWriter.WriteLine(person.ToString());
                _streamWriter.WriteLine(person.Surname);
                _streamWriter.WriteLine(person.Bank);
                _streamWriter.WriteLine(person.AccountNumber);
                _streamWriter.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public List<PersonData> ReadFile(string filePath)
        {
            _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            _streamReader = new StreamReader(_fileStream);
            var fileContent = _streamReader.ReadToEnd();
            _streamReader.Close();

            var fileContentArray = fileContent.Split('\n');
            PersonData person;                                                  //gdzie to dać?
            _fileContentList = new List<PersonData>();

            for (int i = 0; i < fileContentArray.Length - 1; i += 4)
            {
                person = new PersonData(fileContentArray[i].Replace("\r", ""), fileContentArray[i + 1].Replace("\r", ""), fileContentArray[i + 2].Replace("\r", ""),
                    fileContentArray[i + 3].Replace("\r", ""));
                _fileContentList.Add(person);
            }

            return _fileContentList;
        }
    }
}