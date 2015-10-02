using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PersonDataFileOperations
{
    public class XmlFileRepository : IFileRepository
    {
        //private FileStream _fileStream;
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private List<PersonData> _fileContentList;
        private readonly XmlRootAttribute _rootAttribute = new XmlRootAttribute()
        {
            ElementName = "Personal Data",
            IsNullable = true
        };
        private XmlSerializer _xmlSerializer;



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
            _fileContentList = FileExist(filePath) ? ReadFile(filePath) : new List<PersonData>();
            _fileContentList.Add(person);

            _xmlSerializer = new XmlSerializer(typeof (List<PersonData>), _rootAttribute);

            try
            {
                _streamWriter = new StreamWriter(filePath);
                _xmlSerializer.Serialize(_streamWriter, _fileContentList);
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
            _fileContentList = new List<PersonData>();
            _xmlSerializer = new XmlSerializer(typeof (List<PersonData>), _rootAttribute);

            if (!FileExist(filePath))
                return _fileContentList;

            _streamReader = new StreamReader(filePath);
            _fileContentList = (List<PersonData>) _xmlSerializer.Deserialize(_streamReader);
            _streamReader.Close();
            return _fileContentList;
        }
    }
}