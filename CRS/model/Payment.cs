using System;
using System.Reflection.Emit;

namespace CRS.model
{
	public class Payment
    {

        private int paymentID;
        private int leaseID;
        private DateTime paymentDate;
        private int amount;

        public int PaymentID   // property
        {
            get { return paymentID; }   // get method
            set { paymentID = value; }  // set method
        }

        public int LeaseID   // property
        {
            get { return leaseID; }   // get method
            set { leaseID = value; }  // set method
        }

        public DateTime PaymentDate   // property
        {
            get { return paymentDate; }   // get method
            set { paymentDate = value; }  // set method
        }

        public int Amount   // property
        {
            get { return amount; }   // get method
            set { amount = value; }  // set method
        }

        public override string ToString()
        {
            return $"Id:: {PaymentID}\t LeaseID:: {LeaseID} \t PaymentDate:: {PaymentDate} \t Amount:: {Amount} ";
        }


        public Payment()
		{
		}

        public Payment(int paymentID,int leaseID,DateTime paymentDate,int amount)
        {
            this.PaymentID = paymentID;
            this.LeaseID = leaseID;
            this.PaymentDate = paymentDate;
            this.Amount = amount;
        }




    }
}

