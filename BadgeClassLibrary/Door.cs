using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeClassLibrary
{
    public class Door
    {
        public Door() { }
        public Door(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
