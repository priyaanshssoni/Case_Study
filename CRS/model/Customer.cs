using System;
using System.Diagnostics;

namespace CRS.model
{
	public class Customer
	{
		private int customerID;
		private string firstName;
		private string lastName;
		private string email;
		private double phoneNumber;

        public int CustomerID   // property
        {
            get { return customerID; }   // get method
            set { customerID = value; }  // set method
        }

        public string FirstName   // property
        {
            get { return firstName; }   // get method
            set { firstName = value; }  // set method
        }

        public string LastName   // property
        {
            get { return lastName; }   // get method
            set { lastName = value; }  // set method
        }


        public string Email   // property
        {
            get { return email; }   // get method
            set { email = value; }  // set method
        }



        public double PhoneNumber   // property
        {
            get { return phoneNumber; }   // get method
            set { phoneNumber = value; }  // set method
        }


        public override string ToString()
        {
            return $"Id:: {CustomerID}\t FirstName:: {FirstName} \tLast Name:: {LastName} \tEmail:: {Email} \tPhoneNumber:: {PhoneNumber}";
        }


        public Customer()
		{
		}

        public Customer(int CustomerID, string FirstName, string LastName, string Email, double PhoneNumber)
        {
            this.CustomerID = CustomerID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
        }




    }
}

