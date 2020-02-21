using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeClassLibrary
{
    public class BadgeRepository
    {
        Dictionary<string, List<Door>> _badgeDirectory = new Dictionary<string, List<Door>>();
        public bool AddBadgeToDirectory(Badge badge)
        {
            int initialCount = _badgeDirectory.Count;
            _badgeDirectory.Add(badge.ID, badge.AccessibleDoors);
            return _badgeDirectory.Count == initialCount + 1;
        }   
        public List<Door> GetListOfDoorsByID(string id)
        {
            List<Door> doors;
            bool isIDPresent = _badgeDirectory.TryGetValue(id, out doors);

            if (isIDPresent)
                return doors;
            else
                return null;
        }
        public bool AddDoorToList(string id, Door door)
        {
            List<Door> doors;

            bool isIDPresent = _badgeDirectory.TryGetValue(id, out doors);

            if (isIDPresent)
            {
                int initialCount = doors.Count;
                doors.Add(door);
                return doors.Count == initialCount + 1;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDoorFromList(string id, Door door)
        {
            List<Door> doors;

            bool isIDPresent = _badgeDirectory.TryGetValue(id, out doors);

            if (isIDPresent)
            {
                Door door1 = doors.Single(c => c.Name == door.Name);
                return doors.Remove(door1);
            }
            else
            {
                return false;
            }
        }
        public Dictionary<string, List<Door>> GetAllBadgesAndDoors()
        {
            return _badgeDirectory;
        }
    }
}
