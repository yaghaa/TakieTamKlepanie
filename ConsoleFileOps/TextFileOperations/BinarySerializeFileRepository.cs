using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PersonDataFileOperations
{
    public class BinarySerializeFileRepository : IFileRepository
    {
        private FileStream _fileStream, _fileStreamOverwrite;
        private BinaryFormatter _binaryFormater;
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
            _fileContentList = new List<PersonData>(); //               gdzie to?
            _fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
                

            try
            {
                _binaryFormater = new BinaryFormatter();
                _fileContentList = (List<PersonData>)_binaryFormater.Deserialize(_fileStream);
                _fileStream.Close();

                _fileStreamOverwrite = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                _fileContentList.Add(person);
                _binaryFormater.Serialize(_fileStreamOverwrite, _fileContentList);
                _fileStreamOverwrite.Close();
                return true;
            }
            catch (SerializationException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        //public string ReadFile(string filePath)
        //{
        //    _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        //    _binaryFormater = new BinaryFormatter();

        //    var person = new PersonData();
        //    person = (PersonData)_binaryFormater.Deserialize(_fileStream);

           

        //    //while (_fileStream. != -1)
        //    //{
        //    //    _fileContent += _binaryReader.ReadString();
        //    //}

        //    _fileStream.Close();

        //    return person.ToString();
        //}

        //public PersonData ReadFile2(string filePath)
        //{
        //    _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        //    _binaryFormater = new BinaryFormatter();

        //    var person = new PersonData();
        //    person = (PersonData)_binaryFormater.Deserialize(_fileStream);



        //    //while (_fileStream. != -1)
        //    //{
        //    //    _fileContent += _binaryReader.ReadString();
        //    //}

        //    _fileStream.Close();

        //    return person;
        //}

        public List<PersonData> ReadFile(string filePath)
        {
            _fileContentList = new List<PersonData>(); //               gdzie to?

            _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            _binaryFormater = new BinaryFormatter();
            _fileContentList = (List<PersonData>)_binaryFormater.Deserialize(_fileStream);
            _fileStream.Close();

            return _fileContentList;
        }
    }
}