using System;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Emit;

namespace CRS.model
{
	public class Lease
	{
		private int leaseID;
		private int vehicleID;
        private int customerID;
		private DateTime startDate;
		private DateTime endDate;
		private string type;


        public int LeaseID   // property
        {
            get { return leaseID; }   // get method
            set { leaseID = value; }  // set method
        }

        public int VehicleID   // property
        {
            get { return vehicleID; }   // get method
            set { vehicleID = value; }  // set method
        }

        public int CustomerID   // property
        {
            get { return customerID; }   // get method
            set { customerID = value; }  // set method
        }

        public DateTime StartDate   // property
        {
            get { return startDate; }   // get method
            set { startDate = value; }  // set method
        }

        public DateTime EndDate   // property
        {
            get { return endDate; }   // get method
            set { endDate = value; }  // set method
        }

        public string Type   // property
        {
            get { return type; }   // get method
            set { type = value; }  // set method
        }


        public override string ToString()
        {
            return $"Id:: {LeaseID}\t VehicleID:: {VehicleID} \t CustomerID:: {CustomerID} \t StartDate:: {StartDate} \t EndDate:: {EndDate} \t Type:: {Type}";
        }

        public Lease()
		{
		}

        public Lease(int leaseID,int vehicleID, int customerID, DateTime startDate, DateTime endDate,string type)
        {
            this.LeaseID = leaseID;
            this.VehicleID = vehicleID;
            this.CustomerID = customerID;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Type = type;
        }



    }
}

