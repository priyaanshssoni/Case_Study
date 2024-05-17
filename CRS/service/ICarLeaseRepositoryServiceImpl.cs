    using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using CRS.dao;
using CRS.model;
using CRS.myexceptions;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRS.service
{
	public class ICarLeaseRepositoryServiceImpl : ICarLeaseRepositoryService
    {


        readonly ICarLeaseRepository _carleaserepository;

        public ICarLeaseRepositoryServiceImpl()
		{
            _carleaserepository = new ICarLeaseRepositoryImpl();

        }

        #region Car Management
      

        public void addCar() 
        {
            try
            {
                Vehicle car = new Vehicle();
                Console.WriteLine("~Add Car Console~ \n Please Fill below details to Add Car");
                Console.WriteLine("Maker");

                car.Make = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(car.Make))
                {
                    throw new Exception("Input cannot be empty or contain only whitespace characters.");
                }
                Console.WriteLine("Model");

                car.Model = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(car.Model))
                {
                    throw new Exception("Input cannot be empty or contain only whitespace characters.");
                }

                Console.WriteLine("Year");

                int yearr;

                if (!int.TryParse(Console.ReadLine(), out yearr))
                {
                    Console.WriteLine(" Please enter a valid integer ID.");
                    return;
                }
                car.Year = yearr;

                Console.WriteLine("Daily Rate");

                int rate;

                if (!int.TryParse(Console.ReadLine(), out rate))
                {
                    Console.WriteLine(" Please enter a valid integers.");
                    return;
                }

                car.DailyRate = rate;

                bool validStatus = false;
                int i = 0;
                while (!validStatus&&i<3)
                {
                    Console.WriteLine("Status : Available/Not Available");
                    string statusInput = Console.ReadLine().ToLower();

                    if (statusInput == "available" || statusInput == "not available")
                    {
                        car.Status = statusInput;
                        validStatus = true;
                    }
                  
                    
                    else
                    {
                       Console.WriteLine("Invalid input! Status should be either 'Available' or 'Not Available'.");
                        i++;
                    }
                }
                if (i == 3)
                {
                    Console.WriteLine("Max Attempts Reached . Returning Back");
                    return;
                }

                Console.WriteLine("Passenger Capacity");

                int pcapacity;

                if (!int.TryParse(Console.ReadLine(), out pcapacity))
                {
                    Console.WriteLine(" Please enter a valid integers.");
                    return;
                }

                car.PassengerCapacity = pcapacity;

                Console.WriteLine("Engine Capacity");

                int ecapacity;

                if (!int.TryParse(Console.ReadLine(), out ecapacity))
                {
                    Console.WriteLine(" Please enter a valid integers.");
                    return;
                }

                car.EngineCapacity = ecapacity;


                _carleaserepository.addCar(car);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void removeCar() 
        {
            try
            {
                Console.WriteLine("~Car Removal Console~ \n Please Enter Car's Vehicle Id");
            List<Vehicle> allvehicle = _carleaserepository.getallcars();
            foreach (Vehicle veh in allvehicle)
            {
                Console.WriteLine($"Car Id : {veh.VehicleID} || Car Name : {veh.Make} {veh.Model} || Availability : {veh.Status}  ");
            }
            int vehid;
            if (!int.TryParse(Console.ReadLine(), out vehid))
            {
                Console.WriteLine(" Please enter a valid integer ID.");
                return;
            }
            

            if (!_carleaserepository.IsCarIdExists(vehid))
            {
                throw new CarNotFoundException($"Car with ID {vehid} not found.");
               
            }

           
                _carleaserepository.removeCar(vehid);
                Console.WriteLine($"Car with Id {vehid} was Removed Sucessfully");
            }
            catch (CarNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void listAvailableCars() 
        {
            try
            {
            Console.WriteLine("~List of Available Cars~");
            List<Vehicle> veh = _carleaserepository.listAvailableCars();
            foreach (Vehicle item in veh)
            {
                Console.WriteLine(item);
            }
        }
            catch(Exception ex)
            {
                  Console.WriteLine(ex.Message);
            }
}

        public void listRentedCars()
        {
            try
            {
                Console.WriteLine("~List of Rented Cars~");
                List<Vehicle> veh = _carleaserepository.listRentedCars();
                foreach (Vehicle item in veh)
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception ex)
            {
                  Console.WriteLine(ex.Message);
            }
        }

        public void findCarById() 
        {
            try
            {
                Console.WriteLine("~Car Finder Console~ \n");
                List<Vehicle> allvehicle = _carleaserepository.getallcars();
                foreach (Vehicle vehi in allvehicle)
                {
                    Console.WriteLine($"Car Id : {vehi.VehicleID} || Car Name : {vehi.Make} {vehi.Model}");
                }

                Console.WriteLine("Please Enter Car's Vehicle Id");
                int vid;
            if (!int.TryParse(Console.ReadLine(), out vid))
            {
                Console.WriteLine(" Please enter a valid integer ID.");
                return;
            }
                if (!_carleaserepository.IsCarIdExists(vid))
                {
                    throw new CarNotFoundException($"Car with ID {vid} not found.");
                }



                List<Vehicle> veh = _carleaserepository.findCarById(vid);

                foreach (Vehicle item in veh)
                {
                    Console.WriteLine(item);
                }
            }
            catch (CarNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        #region Customer Management

    


        public void addCustomer() 
        {
            try
        {
            Customer customer = new Customer();
            Console.WriteLine("~Add Customer Console~ \t Please Fill below details to Add Customer");
            Console.WriteLine("First Name");
            customer.FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.FirstName))
                {
                    throw new Exception("Input cannot be empty or contain only whitespace characters.");
                }
                Console.WriteLine("Last Name");
            customer.LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.LastName))
                {
                    throw new Exception("Input cannot be empty or contain only whitespace characters.");
                }
                Console.WriteLine("Email");
            customer.Email = Console.ReadLine().ToLower();
            if (!customer.Email.Contains("@") && !customer.Email.Contains(".com"))
            {
                throw new InvalidDataException("Invalid email format. Please use the format: abc@example.com");

            }

            Console.WriteLine("Phone Number");
            string phonenum = (Console.ReadLine());
                if (!IsNumeric(phonenum))
                {
                    throw new InvalidDataException("Phone Number should contain only numbers.");
                }

                if (phonenum.Length != 10)
                {
                    throw new InvalidDataException("Phone Number should be 10 digits long.");
                }
                bool IsNumeric(string str)
                {
                    foreach (char c in str)
                    {
                        if (!char.IsDigit(c))
                        {
                            return false;
                        }
                    }
                    return true;
                }

                customer.PhoneNumber = Convert.ToDouble(phonenum); 
    
                int status = _carleaserepository.addCustomer(customer);



        }
             catch (InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void updateCustomerDetails() 
        {
            try
            {

            Customer customer = new Customer();
            Console.WriteLine("~Update Customer Console~ \t Please Fill below details to Update Customer Details");

                Console.WriteLine("~List of All Customers~");
            
                List<Customer> car = _carleaserepository.listCustomers();
                foreach (Customer item in car)
                {
                    Console.WriteLine($"Customer Id :: {item.CustomerID} Name :: {item.FirstName} {item.LastName}");
                }


                Console.WriteLine("Select Customer Id ");
                int cid;
                if (!int.TryParse(Console.ReadLine(), out cid))
                {
                    Console.WriteLine(" Please enter a valid integers.");
                    return;
                }

                customer.CustomerID = cid;

                if (!_carleaserepository.IsCustomerIdExists(customer.CustomerID))
                {
                    throw new CustomerrNotFoundException($"Customer with ID {customer.CustomerID} not found.");
                }

                Console.WriteLine("First Name"); 
            customer.FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.FirstName))
                {
                    throw new Exception("Input cannot be empty or contain only whitespace characters.");
                }
                Console.WriteLine("Last Name");
            customer.LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.LastName))
                {
                    throw new Exception("Input cannot be empty or contain only whitespace characters.");
                }
                Console.WriteLine("Email");
            customer.Email = Console.ReadLine().ToLower();
            if (!customer.Email.Contains("@") && !customer.Email.Contains(".com"))
            {
                throw new InvalidDataException("Invalid email format. Please use the format: abc@example.com");

            }
            Console.WriteLine("Phone Number");
            string phonenum = (Console.ReadLine());
                if (!IsNumeric(phonenum))
                {
                    throw new InvalidDataException("Phone Number should contain only numbers.");
                }

                if (phonenum.Length != 10)
                {
                    throw new InvalidDataException("Phone Number should be 10 digits long.");
                }
          
                bool IsNumeric(string str)
                {
                    foreach (char c in str)
                    {
                        if (!char.IsDigit(c))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                customer.PhoneNumber = Convert.ToDouble(phonenum);


             _carleaserepository.updateCustomerDetails(customer);
            
            }
            catch (CustomerrNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void removeCustomer() 
        {
            try
            {
     
            Console.WriteLine("~Customer Removal Console~ \n Please Enter Customer's Customer Id");
                Console.WriteLine("~List of All Customers~");
        
                List<Customer> car = _carleaserepository.listCustomers();
                foreach (Customer item in car)
                {
                    Console.WriteLine($"Customer Id :: {item.CustomerID} Name :: {item.FirstName} {item.LastName}");
                }

                int vid;
            if (!int.TryParse(Console.ReadLine(), out vid))
            {
                Console.WriteLine(" Please enter a valid integer ID.");
                return;
            }

            if (!_carleaserepository.IsCustomerIdExists(vid))
            {
                throw new CustomerrNotFoundException($"Customer with ID {vid} not found.");
            }

             _carleaserepository.removeCustomer(vid);
            }
            catch (CustomerrNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void listCustomers() 
        {
            try
            {
                Console.WriteLine("~List of Customers~");
            
                List<Customer> car = _carleaserepository.listCustomers();
                foreach (Customer item in car)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void findCustomerById() 
        {
            Console.WriteLine("~Customer Finder Console~ \t ");
            try
            {
                Console.WriteLine("~List of Customers~");
         
                List<Customer> car = _carleaserepository.listCustomers();
                foreach (Customer item in car)
                {
                    Console.WriteLine($"Customer Id :: {item.CustomerID} Name :: {item.FirstName} {item.LastName}");
                }
                Console.WriteLine("~Please Enter Customer Id~ \t ");
                int vid;
                if (!int.TryParse(Console.ReadLine(), out vid))
                {
                    Console.WriteLine(" Please enter a valid integer ID.");
                    return;
                }
                if (!_carleaserepository.IsCustomerIdExists(vid))
                {
                    throw new CustomerrNotFoundException($"Customer with ID {vid} not found.");
                }

                Console.WriteLine(_carleaserepository.findCustomerById(vid));
            }
                
            catch (CustomerrNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
        #region Lease Management

        public void totalLeaseCost() 
        {

            try
            {

                Console.WriteLine("~Lease Cost Calculation Console~ \t");
            Console.WriteLine("Enter Lease Id");
            int vid;
            if (!int.TryParse(Console.ReadLine(), out vid))
            {
                Console.WriteLine(" Please enter a valid integer ID.");
                return;
            }
            if (!_carleaserepository.IsLeaseIdExists(vid))
            {
                throw new LeaseNotFoundException($"Lease with ID {vid} not found.");
            }

            Console.WriteLine($"~Total Cost for Lease {vid} ~ \t");
            Console.WriteLine(_carleaserepository.totalLeaseCost(vid));
            }
            
            catch (LeaseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void createLease() 
        {
            try
            {
                Console.WriteLine("~Add Lease Console~ \t Please Fill below details to Add Lease");
                List<Customer> car = _carleaserepository.listCustomers();
                foreach (Customer item in car)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Please Enter The Customer Id");
                int CustomerID;
                if (!int.TryParse(Console.ReadLine(), out CustomerID))
                {
                    Console.WriteLine(" Please enter a valid integer ID.");
                    return;
                }
                if (!_carleaserepository.IsCustomerIdExists(CustomerID))
                {
                    throw new CustomerrNotFoundException($"Customer with ID {CustomerID} not found.");
                }

                List<Vehicle> veh = _carleaserepository.listAvailableCars();
                foreach (Vehicle item in veh)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine(" Please Choose Vehicle Id");
                int VehicleID;
                if (!int.TryParse(Console.ReadLine(), out VehicleID))
                {
                    Console.WriteLine(" Please enter a valid integer ID.");
                    return;
                }


                if (!_carleaserepository.IsCarIdExists(VehicleID))
                {
                    throw new CarNotFoundException($"Car with ID {VehicleID} not found.");

                }


                Lease lease1 = new Lease();
                //    Console.WriteLine("Start Date (yyyy-mm-dd)");
                //   DateTime StartDate = Convert.ToDateTime(Console.ReadLine());
                //    Console.WriteLine("End Date (yyyy-mm-dd)");
                //     DateTime EndDate = Convert.ToDateTime(Console.ReadLine());
                int attempts = 0;
                DateTime StartDate = DateTime.MinValue;

                while (attempts<3)
                {
                    Console.WriteLine("Start Date (yyyy-mm-dd)");
                    if (DateTime.TryParse(Console.ReadLine(), out StartDate))
                        break;
                    Console.WriteLine("Invalid date format. Please try again.");
                    attempts++;
                }
                if (attempts == 3)
                {
                    Console.WriteLine("Max Attempts Reached. Returning Back");
                    return;
                }
                
                attempts = 0;
                DateTime EndDate = DateTime.MinValue; 
                while (attempts < 3)
                {
                    Console.WriteLine("End Date (yyyy-mm-dd)");
                    if (DateTime.TryParse(Console.ReadLine(), out EndDate))
                    {
                        if (EndDate < StartDate)
                        {
                            Console.WriteLine("End date cannot be before start date. Please try again.");
                            attempts++;
                            continue;
                        }
                        break;
                    }
                    Console.WriteLine("Invalid date format. Please try again.");
                    attempts++;
                }

                if (attempts == 3)
                {
                    Console.WriteLine("Mex Attempts Reached. Returning Back");
                    return;
                }

                bool validStatus = false;
                int i = 0;
                while (!validStatus&&i <3)
                {
                    Console.WriteLine("Lease Type : DailyLease/MonthlyLease");
                    string statusInput = Console.ReadLine().ToLower();

                    if (statusInput == "dailylease" || statusInput == "monthlylease")
                    {
                        lease1.Type = statusInput; 
                        validStatus = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Status should be either 'DailyLease' or 'MonthlyLease' ");
                        i++;
                    }
                }

                if (i == 3)
                {
                    Console.WriteLine("Mex Attempts Reached. Returning Back");
                    return;

                }

                double cost_of_lease = _carleaserepository.LeaseCost(VehicleID, StartDate, EndDate);
                Console.WriteLine($"You Total Cost for The Lease Will Be : {cost_of_lease} ");

                Console.WriteLine("Would You Like To Create the Lease? Yes/No ");
                string question = Convert.ToString(Console.ReadLine());
                if (question == "Yes" || question == "yes")
                {
                    int getaddstatus = _carleaserepository.createLease(VehicleID, CustomerID, StartDate, EndDate, lease1.Type);
                    if (getaddstatus > 0)
                    {
                        Console.WriteLine("Lease Addition Sucessful");
                    }
                    else
                        Console.WriteLine("Lease Addition UnSucessful");
                }
                else
                    Console.WriteLine("Lease Addition UnSucessful");
            }
            catch (CustomerrNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CarNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
  
           

        }



        public void returnCar() 
        {
            try
            {
                Console.WriteLine("~Lease Infromation Retrieval Console~ \t ");

                 Console.WriteLine("~List of Lease:");
                 List<Lease> lease1 = _carleaserepository.listallLease();
                 foreach (Lease item in lease1)
                 {
                     Console.WriteLine(item);
                 }
                Lease leasee = new Lease();
                Console.WriteLine("Enter Lease Id");
                int vid;
                if (!int.TryParse(Console.ReadLine(), out vid))
                {
                    Console.WriteLine(" Please enter a valid integer ID.");
                    return;
                }
                leasee.LeaseID = vid;
                if (!_carleaserepository.IsLeaseIdExists(leasee.LeaseID))
                {
                    throw new LeaseNotFoundException($"Lease with ID {leasee.LeaseID} not found.");
                }

                  Console.WriteLine(_carleaserepository.returnCar(leasee.LeaseID));
                  

            }
            catch (LeaseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void listActiveLeases()
        {
            try
            {
                Console.WriteLine("~List of Active Leases~");
                List<Lease> lease1 = _carleaserepository.listActiveLeases();
                foreach (Lease item in lease1)
                {
                    Console.WriteLine(item);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void listLeaseHistory()
        {
            try { 
            Console.WriteLine("~List of Past Leases~");
            List<Lease> lease1 = _carleaserepository.listLeaseHistory();
            foreach (Lease item in lease1)
            {
                Console.WriteLine(item);
            }
        }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
}

        public void calculatetotalleaseCost()
        {

            try
            {
                Console.WriteLine("~Lease Cost Calculation Console~ \n ");
                Console.WriteLine("Would You Like To Calculate Lease Cost By : ");
                Console.WriteLine("1. Lease Id \n 2. Manually  ");
                Console.WriteLine("Please Enter Option No. \t ");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine(" Please enter a valid integer ID.");
                    return;
                }
                if (option == 1)
                {
                    Console.WriteLine("~List of All Lease:");
                    List<Lease> lease1 = _carleaserepository.listallLease();
                    foreach (Lease item in lease1)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine(" Please Select Lease Id");
                    int leaid;
                    if (!int.TryParse(Console.ReadLine(), out leaid))
                    {
                        Console.WriteLine(" Please enter a valid integer ID.");
                        return;
                    }
                    if (!_carleaserepository.IsLeaseIdExists(leaid))
                    {
                        throw new LeaseNotFoundException($"Lease with ID {leaid} not found.");
                    }
                    Console.WriteLine($"~Total Cost for Lease Id {leaid} ~ \t");
                    Console.WriteLine(_carleaserepository.totalLeaseCost(leaid));


                }

                if (option == 2)
                {
                    Lease leasenew = new Lease();
                    bool validStatus = false;
                    int i = 0;
                    while (!validStatus && i < 2)
                    {
                        Console.WriteLine("Lease Type : DailyLease/MonthlyLease");
                        string statusInput = Console.ReadLine().ToLower();

                        if (statusInput == "dailylease" || statusInput == "monthlylease")
                        {
                            leasenew.Type = statusInput;
                            validStatus = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Status should be either 'DailyLease' or 'MonthlyLease' ");
                            i++;
                        }

                        if (leasenew.Type == "dailylease")
                        {
                            Console.WriteLine(" Please Enter Number of Days");
                            int number_of_days;
                            if (!int.TryParse(Console.ReadLine(), out number_of_days))
                            {
                                Console.WriteLine(" Please enter a valid integer ID.");
                                return;
                            }

                            List<Vehicle> allvehicle = _carleaserepository.getallcars();
                            foreach (Vehicle vehi in allvehicle)
                            {
                                Console.WriteLine($"Car Id : {vehi.VehicleID} || Car Name : {vehi.Make} {vehi.Model}");
                            }

                            Console.WriteLine("Please Enter Car's Vehicle Id");
                            int vid;
                            if (!int.TryParse(Console.ReadLine(), out vid))
                            {
                                Console.WriteLine(" Please enter a valid integer ID.");
                                return;
                            }
                            if (!_carleaserepository.IsCarIdExists(vid))
                            {
                                throw new CarNotFoundException($"Car with ID {vid} not found.");
                            }
                            int rate = 0;
                            List<Vehicle> veh = _carleaserepository.findCarById(vid);
                            Vehicle calccar = new Vehicle();
                            foreach (Vehicle item in veh)
                            {
                                int abc = item.DailyRate;

                                rate = abc;
                            }

                            int amount = rate * number_of_days;
                            Console.WriteLine($"Your Total Cost for {number_of_days} will be {rate * number_of_days}");
                        }
                        if (leasenew.Type == "monthlylease")
                        {
                            Console.WriteLine(" Please Enter Number of Months");
                            int number_of_months;
                            if (!int.TryParse(Console.ReadLine(), out number_of_months))
                            {
                                Console.WriteLine(" Please enter a valid integer ID.");
                                return;
                            }

                            List<Vehicle> allvehicle = _carleaserepository.getallcars();
                            foreach (Vehicle vehi in allvehicle)
                            {
                                Console.WriteLine($"Car Id : {vehi.VehicleID} || Car Name : {vehi.Make} {vehi.Model}");
                            }

                            Console.WriteLine("Please Enter Car's Vehicle Id");
                            int vid;
                            if (!int.TryParse(Console.ReadLine(), out vid))
                            {
                                Console.WriteLine(" Please enter a valid integer ID.");
                                return;
                            }
                            if (!_carleaserepository.IsCarIdExists(vid))
                            {
                                throw new CarNotFoundException($"Car with ID {vid} not found.");
                            }
                            int rate = 0;
                            List<Vehicle> veh = _carleaserepository.findCarById(vid);
                            Vehicle calccar = new Vehicle();
                            foreach (Vehicle item in veh)
                            {
                                int drate = item.DailyRate;

                                rate = drate;
                            }
                            int amount = rate * 30 * number_of_months;
                            Console.WriteLine($"Your Total Cost for {number_of_months} Months will be {amount}");
                        }
                    }




                }

            }
            catch (LeaseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        #endregion
        #region Payment Handling

        public void recordPayment()
        {
            try
            {
                Lease lease = new Lease();
                Console.WriteLine("~Add Payment Console~ \t Please Fill below details to Add Payment");
                //need to get leases list here
                Console.WriteLine("~List of All Lease:");
                List<Lease> lease1 = _carleaserepository.listallLease();
                foreach (Lease item in lease1)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(" Please Select Lease Id");
                int leaid;
                if (!int.TryParse(Console.ReadLine(), out leaid))
                {
                    Console.WriteLine(" Please enter a valid integer ID.");
                    return;
                }
                if (!_carleaserepository.IsLeaseIdExists(leaid))
                {
                    throw new LeaseNotFoundException($"Lease with ID {leaid} not found.");
                }
                if (_carleaserepository.findPaymentByLeaseId(leaid))
                {
                    throw new Exception($"Lease with ID {leaid} has already paid.");
                }

                lease.LeaseID = leaid;


                double amount = _carleaserepository.totalLeaseCost(lease.LeaseID);
                Console.WriteLine($"Would You Like To Pay {amount} for Lease Id {lease.LeaseID}? Yes/No");
                string question = Console.ReadLine().ToLower();
                if (question == "yes")
                {
                    _carleaserepository.recordPayment(lease);

                }
                else
                {
                    Console.WriteLine("Payment Record Unsuccesful");
                }
            }
            catch (LeaseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

     
            
       

        public void paymentHistory() 
        {
            try
            {
                Customer customer = new Customer();

                Console.WriteLine("~Payment History Console~ \t Please Fill below detail to Fetch Payment History");
                List<Customer> car = _carleaserepository.listCustomers();
                foreach (Customer item in car)
                {
                    Console.WriteLine($"Customer Id :: {item.CustomerID} Name :: {item.FirstName} {item.LastName}");
                }

                Console.WriteLine("Please Enter Customer Id ");

                int cid;
                if (!int.TryParse(Console.ReadLine(), out cid))
                {
                    Console.WriteLine(" Please enter a valid integers.");
                    return;
                }

                customer.CustomerID = cid;

                if (!_carleaserepository.IsCustomerIdExists(customer.CustomerID))
                {
                    throw new CustomerrNotFoundException($"Customer with ID {customer.CustomerID} not found.");
                }

                List<Payment> pay = _carleaserepository.paymentHistory(customer);
                foreach (Payment item in pay)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public void totalRevenue()
        {
            Console.WriteLine("~Total Revenue from All Leases~");
            Console.WriteLine(_carleaserepository.totalRevenue());


        }


        #endregion
    }
}



