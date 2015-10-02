using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonDataFileOperations;

namespace ConsoleFileOps
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ////  var filePath = "C:\\aga\\06_Robocze\\TextFileOps.txt";
            ////  var filePath = "C:\\aga\\06_Robocze\\TextFileOps.bin";
            //var filePath = "C:\\aga\\06_Robocze\\TextFileOps.xml";

            ////  IFileRepository textOps = new TextFileRepository();
            ////  IFileRepository textOps = new BinaryFileRepository();
            ////  IFileRepository textOps = new BinarySerializeFileRepository();
            ////  IFileRepository textOps = new XmlFileRepository();
            //IFileRepository textOps = new XmlDomFileRepository();

            //var fileService = new FileService(textOps);

            //Console.WriteLine(fileService.SaveFile(new PersonData("test", "testsurname", "Bank BGŻ", "12549864135"), filePath));


            ////foreach (var person in fileService.ReadFile(filePath))
            ////{
            ////    var test = person.ToString();
            ////    Console.WriteLine(test);
            ////}

            ////Console.WriteLine("Długość lisy: "+fileService.ReadFile(filePath).Count);

            //Console.WriteLine();
            //Console.WriteLine(fileService.FileData(filePath));

            //Console.ReadKey();

            Console.Title="Hello world!";
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ReadKey();
            Console.SetWindowSize(60,40);
            Console.SetCursorPosition(10,10);

            int i = 5;

            Console.WriteLine(i++);
            Console.WriteLine(++i);

            Console.WriteLine("Tytuł tego okna to: "+Console.Title);
            Console.ReadKey();
            Console.Clear();
            Console.Beep();
            Console.ReadKey();


        }
    }
}