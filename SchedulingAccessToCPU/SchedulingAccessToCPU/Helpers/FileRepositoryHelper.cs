using System.IO;

namespace SchedulingAccessToCPU
{
    public class FileRepositoryHelper
    {
        private static FileInfo _fileInfo;
        private static string _info;

        public static bool FileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public static string FileData(string filePath)
        {
            if (!FileExist(filePath)) return "Plik nie istnieje.";

            _fileInfo = new FileInfo(filePath);

            _info += "Pełna ścieżka: ";
            _info += _fileInfo.FullName;
            _info += "\nKatalog macierzysty: ";
            _info += _fileInfo.Directory;
            _info += "\nData utworzenia: ";
            _info += _fileInfo.CreationTime.ToString();
            _info += "\nData ostatniego dostępu: ";
            _info += _fileInfo.LastAccessTime.ToShortDateString();
            _info += "\nData zapisu: ";
            _info += _fileInfo.LastWriteTime.ToString();
            _info += "\nAtrybuty: ";
            _info += _fileInfo.Attributes.ToString();

            return _info;
        }  
    }
}