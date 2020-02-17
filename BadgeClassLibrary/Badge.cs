using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeClassLibrary
{
    public class Badge
    {
        public Badge() { }
        public Badge(string id, List<Door> accessibleDoors)
        {
            this.ID = id;
            this.AccessibleDoors = accessibleDoors;
        }
        public string ID { get; set; }
        public List<Door> AccessibleDoors { get; set; }
        public string AccessibleDoorsAsString()
        {
            string result = "";
            foreach(var door in this.AccessibleDoors)
            {
                result += door.Name + " ";
            }
            return result;
        }
    }
}
