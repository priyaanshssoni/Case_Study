using System;
using System.Xml.Linq;

namespace CRS.model
{
	public class Vehicle
    {
        private int vehicleID;
        private string make;
        private string model;
        private int year;
        private int dailyRate;
        private string status;
        private int passengerCapacity;
        private int engineCapacity;

        public int VehicleID   // property
        {
            get { return vehicleID; }   // get method
            set { vehicleID = value; }  // set method
        }
        public string Make   // property
        {
            get { return make; }   // get method
            set { make = value; }  // set method
        }

        public string Model   // property
        {
            get { return model; }   // get method
            set { model = value; }  // set method
        }

        public int Year   // property
        {
            get { return year; }   // get method
            set { year = value; }  // set method
        }

        public int DailyRate   // property
        {
            get { return dailyRate; }   // get method
            set { dailyRate = value; }  // set method
        }

        public string Status   // property
        {
            get { return status; }   // get method
            set { status = value; }  // set method
        }

        public int PassengerCapacity   // property
        {
            get { return passengerCapacity; }   // get method
            set { passengerCapacity = value; }  // set method
        }

        public int EngineCapacity   // property
        {
            get { return engineCapacity; }   // get method
            set { engineCapacity = value; }  // set method
        }

        public override string ToString()
        {
            return $"Id:: {VehicleID}\t Maker:: {Make} \t Model:: {Model} \tYear:: {Year} \nDailyRate:: {DailyRate} \t Status:: {Status}  \t PassengerCapacity:: {PassengerCapacity}\t EngineCapacity:: {EngineCapacity}";
        }



        public Vehicle()
		{
		}

        public Vehicle(int Vehicleid,string Make,string Model ,int Year,int DailyRate,string Status, int PassengerCapacity,int EngineCapacity)
        {
            this.VehicleID = Vehicleid;
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.DailyRate = DailyRate;
            this.Status = Status;
            this.PassengerCapacity = PassengerCapacity;
            this.EngineCapacity = EngineCapacity;
        }



    }


}

