using System.Collections.Generic;
using System.IO;
using System;
using SchedulingAccessToCPU;

namespace SchedulingAccessToCPU
{
    public class TextFileSchedulingAccessToCPU
    {
        private FileStream _fileStream;
        private StreamWriter _streamWriter;
        //private StreamReader _streamReader;
        //private List<Process> _fileContentList;

        public bool FileExist(string filePath)
        {
            return FileRepositoryHelper.FileExist(filePath);
        }

        public string FileData(string filePath)
        {
            return FileRepositoryHelper.FileData(filePath);
        }

        public bool SaveFile(List<Process> listProcesses, string filePath)
        {
            _fileStream =  new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);

            try
            {
                _streamWriter = new StreamWriter(_fileStream);
                foreach (var process in listProcesses)
                {
                    _streamWriter.WriteLine(process.ToString());
                }
                _streamWriter.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        //public List<Process> ReadFile(string filePath)
        //{
        //    _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        //    _streamReader = new StreamReader(_fileStream);
        //    var fileContent = _streamReader.ReadToEnd();
        //    _streamReader.Close();

        //    var fileContentArray = fileContent.Split('\n');
        //    PersonData person;                                                  //gdzie to dać?
        //    _fileContentList = new List<PersonData>();

        //    for (int i = 0; i < fileContentArray.Length - 1; i += 4)
        //    {
        //        person = new PersonData(fileContentArray[i].Replace("\r", ""), fileContentArray[i + 1].Replace("\r", ""), fileContentArray[i + 2].Replace("\r", ""),
        //            fileContentArray[i + 3].Replace("\r", ""));
        //        _fileContentList.Add(person);
        //    }

        //    return _fileContentList;
        //}
    }
}