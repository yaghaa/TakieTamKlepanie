using System;
using System.Collections.Generic;
using System.IO;

namespace PersonDataFileOperations
{
    public class BinaryFileRepository : IFileRepository
    {
        private FileStream _fileStream;
        private BinaryWriter _binaryWriter;
        private BinaryReader _binaryReader;
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
                _binaryWriter = new BinaryWriter(_fileStream);
                _binaryWriter.Write(person.Name);
                _binaryWriter.Write(person.Surname);
                _binaryWriter.Write(person.Bank);
                _binaryWriter.Write(person.AccountNumber);
                _binaryWriter.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        //public string ReadFile(string filePath)
        //{
        //    _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        //    _binaryReader = new BinaryReader(_fileStream);

        //    while (_binaryReader.PeekChar() != -1)
        //    {
        //        _fileContent += _binaryReader.ReadString();
        //    }

        //    _binaryReader.Close();

        //    return _fileContent;
        //}

        public List<PersonData> ReadFile(string filePath)
        {
            PersonData person;                                                  //gdzie to dać?
            _fileContentList = new List<PersonData>();

            _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            _binaryReader = new BinaryReader(_fileStream);

            while (_binaryReader.PeekChar() != -1)
            {
                var name = _binaryReader.ReadString();
                var surname = _binaryReader.ReadString();
                var bank = _binaryReader.ReadString();
                var accountNumber = _binaryReader.ReadString();
                person = new PersonData(name, surname, bank, accountNumber);
                _fileContentList.Add(person);
            }

            _binaryReader.Close();
            
            return _fileContentList;
        }

    }
}