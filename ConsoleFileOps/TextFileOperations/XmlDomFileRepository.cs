using System.Collections.Generic;
using System.Xml;

namespace PersonDataFileOperations
{
    public class XmlDomFileRepository : IFileRepository
    {
        private XmlTextWriter _textWriter;

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
            if (FileExist(filePath))
            {
                var listSize = 0;

                XmlTextReader Reader = new XmlTextReader(filePath);
 
                  while (Reader.Read())
                  {
                       listSize++;
                  }
                 Reader.Close();
            }

            _textWriter = new XmlTextWriter(filePath, null);

            _textWriter.Formatting = Formatting.Indented;
            _textWriter.Indentation = 4;
            _textWriter.WriteStartDocument();
            _textWriter.WriteStartElement("PersonalData");
                _textWriter.WriteStartElement("PersonData");

                    _textWriter.WriteStartElement("Name");
                    _textWriter.WriteString(person.Name);
                    _textWriter.WriteEndElement();                    
                    _textWriter.WriteStartElement("Surname");
                    _textWriter.WriteString(person.Surname);
                    _textWriter.WriteEndElement();
                    _textWriter.WriteStartElement("Bank");
                    _textWriter.WriteString(person.Bank);
                    _textWriter.WriteEndElement();
                    _textWriter.WriteStartElement("AccountNumber");
                    _textWriter.WriteString(person.AccountNumber);
                    _textWriter.WriteEndElement();

                _textWriter.WriteEndElement();
            _textWriter.WriteEndElement();
            _textWriter.WriteEndDocument();
            _textWriter.Close();
            return true;
        }

        public List<PersonData> ReadFile(string filePath)
        {
            List<PersonData> fileContentList = new List<PersonData>();
            return fileContentList;
        }
    }
}