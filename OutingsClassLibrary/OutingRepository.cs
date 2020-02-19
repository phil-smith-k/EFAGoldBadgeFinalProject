using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingsClassLibrary
{
    public class OutingRepository
    {
        List<IOuting> _outingRepository = new List<IOuting>();
        public bool AddOuting(IOuting outing)
        {
            int initialCount = _outingRepository.Count;
            _outingRepository.Add(outing);
            return initialCount + 1 == _outingRepository.Count;
        }
        public List<IOuting> GetAllOutings()
        {
            return _outingRepository;
        }
        public decimal GetTotalCostOfGolfOutings()
        {
            return _outingRepository.Where(c => c is GolfOuting).Sum(d => d.TotalCost);
        }
        public decimal GetTotalCostOfBowlingOutings()
        {
            return _outingRepository.Where(c => c is BowlingOuting).Sum(d => d.TotalCost);
        }
        public decimal GetTotalCostOfAmusementParkOutings()
        {
            return _outingRepository.Where(c => c is AmusementParkOuting).Sum(d => d.TotalCost);
        }
        public decimal GetTotalCostOfConcertOutings()
        {
            return _outingRepository.Where(c => c is ConcertOuting).Sum(d => d.TotalCost);
        }
        public decimal GetTotalCostOfAllOutings()
        {
            return _outingRepository.Sum(c => c.TotalCost);
        }
    }
}
