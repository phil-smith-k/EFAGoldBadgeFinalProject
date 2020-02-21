using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenCarClasses
{
    public interface ICar
    {
        string Make { get; set; }
        string Model { get; set; }
        int Year { get; set; }
        int MilesPerGallon { get; set; }
    }
}
