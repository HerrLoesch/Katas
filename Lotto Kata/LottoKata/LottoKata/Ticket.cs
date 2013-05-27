using System.Collections.Generic;

namespace LottoKata
{
    public class Ticket
    {
        public Ticket(List<int> numbers, int additional, int super)
        {
            Numbers = numbers;
            Additional = additional;
            Super = super;
        }

        public Ticket()
        {

        }

        public List<int> Numbers { get; set; }
        public int Additional { get; set; }
        public int Super { get; set; }
    }
}