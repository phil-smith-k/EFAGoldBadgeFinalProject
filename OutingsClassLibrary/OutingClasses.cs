using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingsClassLibrary
{
    public class GolfOuting : IOuting
    {
        public GolfOuting() { }
        public GolfOuting(DateTime date, int numberAttended, decimal costPerPerson, decimal totalCost)
        {
            this.Date = date;
            this.NumberAttended = numberAttended;
            this.CostPerPerson = costPerPerson;
            this.TotalCost = totalCost;
        }
        public string Type { get; } = "Golf";
        public int NumberAttended { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }
    }
    public class BowlingOuting : IOuting
    {
        public BowlingOuting() { }
        public BowlingOuting(DateTime date, int numberAttended, decimal costPerPerson, decimal totalCost)
        {
            this.Date = date;
            this.NumberAttended = numberAttended;
            this.CostPerPerson = costPerPerson;
            this.TotalCost = totalCost;
        }
        public string Type { get; } = "Bowling";
        public int NumberAttended { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }
    }
    public class AmusementParkOuting : IOuting
    {
        public AmusementParkOuting() { }
        public AmusementParkOuting(DateTime date, int numberAttended, decimal costPerPerson, decimal totalCost)
        {
            this.Date = date;
            this.NumberAttended = numberAttended;
            this.CostPerPerson = costPerPerson;
            this.TotalCost = totalCost;
        }
        public string Type { get; } = "Amusement Park";
        public int NumberAttended { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }
    }
    public class ConcertOuting : IOuting
    {
        public ConcertOuting() { }
        public ConcertOuting(DateTime date, int numberAttended, decimal costPerPerson, decimal totalCost)
        {
            this.Date = date;
            this.NumberAttended = numberAttended;
            this.CostPerPerson = costPerPerson;
            this.TotalCost = totalCost;
        }
        public string Type { get; } = "Concert";
        public int NumberAttended { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }
    }
}
