using System.Collections.Generic;

namespace P05_GreedyTimes
{
    public class UnitType
    {
        public UnitType(string name)
        {
            this.Name = name;
            this.Units = new List<Unit>();
        }
        public string Name { get; set; }
        public long TotalAmount { get; set; }
        public List<Unit> Units { get; set; }
    }
}
