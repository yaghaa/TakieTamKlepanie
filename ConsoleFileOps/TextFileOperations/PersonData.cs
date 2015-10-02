using System;

namespace PersonDataFileOperations
{
    [Serializable]
    public class PersonData
    {
        public string Name;
        public string Surname;
        public string Bank;
        public string AccountNumber;

        public PersonData()
        {
            
        }

        public PersonData(string name, string surname, string bank, string accountNumber)
        {
            Name = name;
            Surname = surname;
            Bank = bank;
            AccountNumber = accountNumber;
        }

        public override string ToString()
        {
            return (Name+" "+Surname+" "+Bank+" "+AccountNumber);
        }

    }
}