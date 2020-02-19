using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingsClassLibrary
{
    public interface IOuting
    {
        string Type { get; }
        int NumberAttended { get; set; }
        DateTime Date { get; set; }
        decimal CostPerPerson { get; set; }
        decimal TotalCost { get; set; }
    }
}
