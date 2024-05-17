using System;
using CRS.model;

namespace CRS.service
{
	public interface ICarLeaseRepositoryService
	{

        //Car Management :
        void addCar();
        void removeCar();
        void listAvailableCars();
        void listRentedCars();
        void findCarById();

        // Customer Management :

        void addCustomer();
        void removeCustomer();
        void listCustomers(); //checked & working
        void findCustomerById();
        void updateCustomerDetails();

        //Lease Management :
        void createLease();
        void returnCar();
        void listActiveLeases();
        void listLeaseHistory();
        void totalLeaseCost();
        void calculatetotalleaseCost();


        //Payment Handling :
        void recordPayment();
        void paymentHistory();
        void totalRevenue();




    }
}

