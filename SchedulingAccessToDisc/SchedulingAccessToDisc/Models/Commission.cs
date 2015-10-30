namespace SchedulingAccessToDisc.Models
{
    public class Commission
    {
        public int CommissionNumber { get; set; }
        public int EntryTime { get; set; }

        public Commission(int comissionNumber, int entryTime)
        {
            CommissionNumber = comissionNumber;
            EntryTime = entryTime;
        }

        public override string ToString()
        {
            return "Numer procesu: " + CommissionNumber + "Czas wejścia: " + EntryTime;
        }
    }
}