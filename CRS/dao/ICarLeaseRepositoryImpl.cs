using System;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using CRS.model;
using CRS.myexceptions;
using Demo_ProductApp.Utility;
using Microsoft.Data.SqlClient;

namespace CRS.dao

{

	public class ICarLeaseRepositoryImpl : ICarLeaseRepository
	{





        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public ICarLeaseRepositoryImpl()
        {
          // sqlConnection = new SqlConnection("Server=localhost;Database=Car_rental;User Id=sa;Password=reallyStrongPwd123;TrustServerCertificate=True");
            sqlConnection = new SqlConnection(PropertyUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        //Car Management
        #region Car Management
        //update car availability
        
        public int updateCarAvailability(Vehicle car)
        {
       
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE VEHICLE SET status = @status WHERE vehicleID = @vid";
                cmd.Parameters.AddWithValue("@vid", car.VehicleID);
                cmd.Parameters.AddWithValue("@status", car.Status);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int updateAvailabilityStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (updateAvailabilityStatus > 0)
                {
                    Console.WriteLine("Car Status Updation Successful");
                }
                else
                {
                    Console.WriteLine("Car Status Updation UnSuccessful");
                }

                return updateAvailabilityStatus;
         
        }

        public bool IsCarIdExists(int carId)
        {
           
            cmd.Parameters.Clear();
            bool exists = false;
            cmd.CommandText = "SELECT COUNT(*) FROM Vehicle WHERE VehicleID = @CarId";
            cmd.Parameters.AddWithValue("@CarId", carId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int count = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            exists = count > 0;
            return exists;
         
        }

        public bool IsCustomerIdExists(int custid)
        {
            
                cmd.Parameters.Clear();
            bool exists = false;
            cmd.CommandText = "SELECT COUNT(*) FROM Customer WHERE customerID = @custid";
            cmd.Parameters.AddWithValue("@custid", custid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int count = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            exists = count > 0;
            return exists;
          
        }

        public bool IsLeaseIdExists(int lid)
        {
            cmd.Parameters.Clear();
            bool exists = false;
            cmd.CommandText = "SELECT COUNT(*) FROM Lease WHERE leaseID = @custid";
            cmd.Parameters.AddWithValue("@custid", lid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int count = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            exists = count > 0;
            return exists;
        }

        public int addCar(Vehicle car)
        {
            //clearing paramateres
           
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO VEHICLE VALUES(@Make,@Model,@Year,@DailyRate,@Status,@PassengerCapacity,@EngineCapacity)";
            cmd.Parameters.AddWithValue("@Make", car.Make);
            cmd.Parameters.AddWithValue("@Model", car.Model);
            cmd.Parameters.AddWithValue("@Year", car.Year);
            cmd.Parameters.AddWithValue("@DailyRate", car.DailyRate);
            cmd.Parameters.AddWithValue("@Status", car.Status);
            cmd.Parameters.AddWithValue("@PassengerCapacity", car.PassengerCapacity);
            cmd.Parameters.AddWithValue("@EngineCapacity", car.EngineCapacity);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int addProductStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (addProductStatus > 0)
            {
                Console.WriteLine("Car Addition Successful");
            }
            else
            {
                Console.WriteLine("Car Addition UnSuccessful");
            }
            return addProductStatus;
        }

        public int removeCar(int vid)
        {

            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM Vehicle WHERE vehicleID = @vid";
            cmd.Parameters.AddWithValue("@vid", vid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int addCarStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return addCarStatus;
        }

        public List<Vehicle> listAvailableCars()
        {
            cmd.Parameters.Clear();
            List<Vehicle> car = new List<Vehicle>();
         
            cmd.CommandText = "SELECT * FROM Vehicle WHERE status = @av";
            cmd.Parameters.AddWithValue("@av","available");
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vehicle car1 = new Vehicle();
                car1.VehicleID = (int)reader["vehicleID"];
                car1.Make = (string)reader["make"];
                car1.Model = (string)reader["model"];
                car1.Year = (int)reader["year"];
                car1.DailyRate = Convert.ToInt32(reader["dailyRate"]);
                car1.Status = (string)reader["status"];
                car1.PassengerCapacity = (int)reader["passengerCapacity"];
                car1.EngineCapacity = (int)reader["engineCapacity"];
                car.Add(car1);
            }
            sqlConnection.Close();
            return car;
        }

        public List<Vehicle> listRentedCars()
        {
            cmd.Parameters.Clear();
            List<Vehicle> car = new List<Vehicle>();
            cmd.CommandText = "select * from Vehicle where status = @notavailable";
            cmd.Parameters.AddWithValue("@notavailable", "not available");
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vehicle car1 = new Vehicle();
                car1.VehicleID = (int)reader["vehicleID"];
                car1.Make = (string)reader["make"];
                car1.Model = (string)reader["model"];
                car1.Year = (int)reader["year"];
                car1.DailyRate = Convert.ToInt32(reader["dailyRate"]);
                car1.Status = (string)reader["status"];
                car1.PassengerCapacity = (int)reader["passengerCapacity"];
                car1.EngineCapacity = (int)reader["engineCapacity"];
                car.Add(car1);
            }
            sqlConnection.Close();
            return car;
        }

        public List<Vehicle> findCarById(int id)
        {
            List<Vehicle> car = new List<Vehicle>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select * from Vehicle where vehicleID = @vid";
            cmd.Parameters.AddWithValue("@vid", id);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vehicle car1 = new Vehicle();
                car1.VehicleID = (int)reader["vehicleID"];
                car1.Make = (string)reader["make"];
                car1.Model = (string)reader["model"];
                car1.Year = (int)reader["year"];
                car1.DailyRate = Convert.ToInt32(reader["dailyRate"]);
                car1.Status = (string)reader["status"];
                car1.PassengerCapacity = (int)reader["passengerCapacity"];
                car1.EngineCapacity = (int)reader["engineCapacity"];
                car.Add(car1);
            }
            sqlConnection.Close();
            return car;
        }
        public List<Vehicle> getallcars()
        {
            cmd.Parameters.Clear();
            List<Vehicle> getc = new List<Vehicle>();
            cmd.CommandText = "SELECT * FROM Vehicle";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vehicle v1 = new Vehicle();
                v1.VehicleID = (int)reader["vehicleID"];
                v1.Make = (string)reader["make"];
                v1.Model = (string)reader["model"];
                v1.Year = (int)reader["year"];
                v1.DailyRate = Convert.ToInt32(reader["dailyRate"]);
                v1.Status = (string)reader["status"];
                v1.PassengerCapacity = (int)reader["passengerCapacity"];
                v1.EngineCapacity = (int)reader["engineCapacity"];




                getc.Add(v1);
            }
            sqlConnection.Close();
            return getc;
        }
        #endregion
    
        #region Customer Management


        public int updateCustomerDetails(Customer updatec1)
        {

            if (!IsCustomerIdExists(updatec1.CustomerID))
            {
                throw new CustomerrNotFoundException($"Customer with ID {updatec1.CustomerID} not found.");
            }
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE Customer set firstName = @firstname,lastName =@lastname,email = @email,phoneNumber = @phoneNumber FROM Customer WHERE customerID = @customerID";
            cmd.Parameters.AddWithValue("@firstName", updatec1.FirstName);
            cmd.Parameters.AddWithValue("@lastName", updatec1.LastName);
            cmd.Parameters.AddWithValue("@email", updatec1.Email);
            cmd.Parameters.AddWithValue("@phoneNumber", updatec1.PhoneNumber);
            cmd.Parameters.AddWithValue("@customerID", updatec1.CustomerID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateCustomerStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (updateCustomerStatus > 0)
            {
                Console.WriteLine("Customer Updation Successful");
            }
            else
            {
                Console.WriteLine("Customer Updation UnSuccessful");
            }
            return updateCustomerStatus;
        }


        public int addCustomer(Customer customer)
        {

            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Customer VALUES(@firstName,@lastName,@email,@phoneNumber)";
            cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@lastName", customer.LastName);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int addProductStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (addProductStatus > 0)
            {
                Console.WriteLine("Customer Addition Successful");
            }
            else
            {
                Console.WriteLine("Customer Addition UnSuccessful");
            }
            return addProductStatus;
            
        }

        public int removeCustomer(int vid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM Customer WHERE customerID = @cid";
            cmd.Parameters.AddWithValue("@cid", vid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int removeCustomerStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (removeCustomerStatus > 0)
            {
                Console.WriteLine("Customer Removal Successful");
            }
            else
            {
                Console.WriteLine("Customer Removal UnSuccessful");
            }

            return removeCustomerStatus;
        }

        public List<Customer> listCustomers()   
        {
            cmd.Parameters.Clear();
            List<Customer> customer = new List<Customer>();
            cmd.CommandText = "SELECT * FROM Customer";
            cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer1 = new Customer();
                    customer1.CustomerID = (int)reader["customerID"];
                    customer1.FirstName = (string)reader["firstName"];
                    customer1.LastName = (string)reader["lastName"];
                    customer1.Email = (string)reader["email"];
                    customer1.PhoneNumber = (double)reader["phoneNumber"];
                    customer.Add(customer1);
                }

            sqlConnection.Close();
            return customer;
           
        }


        public Customer findCustomerById(int customerID)
        {
            cmd.Parameters.Clear();
            Customer customer = new Customer();
            cmd.CommandText = "select * from Customer where customerID = @customerID";
            cmd.Parameters.AddWithValue("@customerID", customerID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customer.CustomerID = (int)reader["customerID"];
                customer.FirstName = (string)reader["firstName"];
                customer.LastName = (string)reader["lastName"];
                customer.Email = (string)reader["email"];
                customer.PhoneNumber = (double)reader["phoneNumber"];

            }
            sqlConnection.Close();
            return customer;
        }

        #endregion
      
        #region Lease Management


        public double totalLeaseCost(int lease_id)
        {
            cmd.Parameters.Clear();
            if (!IsLeaseIdExists(lease_id))
            {
                throw new LeaseNotFoundException($"Car with ID {lease_id} not found.");
            }
            cmd.CommandText = "SELECT startdate , endDate , type , dailyRate FROM Lease l JOIN Vehicle v ON v.vehicleID = l.vehicleID where leaseID = @leaseID ";
            cmd.Parameters.AddWithValue("@leaseID", lease_id);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            Lease lease1 = new Lease();
            Vehicle veh = new Vehicle();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lease1.StartDate = Convert.ToDateTime(reader["startdate"]);
                lease1.EndDate = Convert.ToDateTime(reader["endDate"]);
                veh.DailyRate= Convert.ToInt32(reader["dailyRate"]);
            }

            DateTime end = lease1.EndDate;
            DateTime start = lease1.StartDate;
            int days = (int)(end - start).TotalDays;
            double amount = veh.DailyRate * days;
            sqlConnection.Close();
            return amount;



        }

        public double LeaseCost(int VehicleID, DateTime StartDate, DateTime EndDate)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT dailyRate FROM Vehicle where vehicleID = @vid ";
            cmd.Parameters.AddWithValue("@vid", VehicleID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            Vehicle veh = new Vehicle();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                veh.DailyRate = Convert.ToInt32(reader["dailyRate"]);
            }

            DateTime end = EndDate;
            DateTime start = StartDate;
            int days = (int)(end - start).TotalDays;
            double amount = veh.DailyRate * days;
            sqlConnection.Close();
            return amount;



        }

        public double CalculateLeaseCost(int VehicleID, int number, string type)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT dailyRate FROM Vehicle where vehicleID = @vid ";
            cmd.Parameters.AddWithValue("@vid", VehicleID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            Vehicle veh = new Vehicle();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                veh.DailyRate = Convert.ToInt32(reader["dailyRate"]);
            }
            int days = number;
            double amount = veh.DailyRate * days;
            sqlConnection.Close();
            return amount;

        }


        public int createLease(int vehicleID, int customerID, DateTime startDate, DateTime endDate,string type)
        {
            
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Lease VALUES(@vehicleid,@customerid,@startdate,@enddate,@type)";
            cmd.Parameters.AddWithValue("@vehicleid", vehicleID);
            cmd.Parameters.AddWithValue("@customerid", customerID);
            cmd.Parameters.AddWithValue("@startdate", startDate);
            cmd.Parameters.AddWithValue("@enddate", endDate);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE VEHICLE SET status = @status WHERE vehicleID = @veid";
            cmd.Parameters.AddWithValue("@veid", vehicleID);
            cmd.Parameters.AddWithValue("@status", "Not Available");
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int addLeaseStatus1 = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return addLeaseStatus1;
        }

        public int returnCar(int leaseid) 
        {
            cmd.Parameters.Clear();
            Vehicle oldcar = new Vehicle();
            Lease lease1 = new Lease();
            cmd.CommandText = "SELECT * FROM Lease WHERE leaseID = @leaseID  ";
            cmd.Parameters.AddWithValue("@leaseid", leaseid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lease1.VehicleID = (int)reader["vehicleID"];
                lease1.EndDate = Convert.ToDateTime(reader["endDate"]);
            }
            sqlConnection.Close();
                oldcar.Status = "available";
                cmd.CommandText = "UPDATE VEHICLE SET status = @status WHERE vehicleID = @vid";
                cmd.Parameters.AddWithValue("@vid", lease1.VehicleID);
                cmd.Parameters.AddWithValue("@status",oldcar.Status);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int status = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            if (status > 0)
            {
                Console.WriteLine("Car Availability Updated");
            }
            return status;
        }
            

        public List<Lease> listActiveLeases() 
        {
            cmd.Parameters.Clear();
            List<Lease> lease = new List<Lease>();
            cmd.CommandText = "select * from Lease where endDate >= GETDATE()";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Lease lease1 = new Lease();
                lease1.LeaseID = (int)reader["leaseID"];
                lease1.VehicleID = (int)reader["vehicleID"];
                lease1.CustomerID = (int)reader["customerID"];
                lease1.StartDate = Convert.ToDateTime(reader["startdate"]);
                lease1.EndDate = Convert.ToDateTime(reader["endDate"]);
                lease1.Type = (string)reader["type"];
                lease.Add(lease1);

            }
            sqlConnection.Close();
            return lease;
        }

        public bool isCaronLease(int activecarid)
        {
            cmd.Parameters.Clear();
            List<Lease> lease = new List<Lease>();
            cmd.CommandText = "select * from Lease where endDate >= GETDATE()";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Lease lease1 = new Lease();
                lease1.LeaseID = (int)reader["leaseID"];
                lease1.VehicleID = (int)reader["vehicleID"];
                lease1.CustomerID = (int)reader["customerID"];
                lease1.StartDate = Convert.ToDateTime(reader["startdate"]);
                lease1.EndDate = Convert.ToDateTime(reader["endDate"]);
                lease1.Type = (string)reader["type"];
                lease.Add(lease1);

            }
            sqlConnection.Close();
            foreach (Lease activelease in lease)
            {
                if (activelease.VehicleID == activecarid)
                {
                    return true;
                }
            }
            
            return false;

        }

        public List<Lease> listLeaseHistory()
        {
            cmd.Parameters.Clear();
            List<Lease> lease = new List<Lease>();
            cmd.CommandText = "select * from Lease where endDate <= GETDATE()";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Lease lease1 = new Lease();
                lease1.LeaseID = (int)reader["leaseID"];
                lease1.VehicleID = (int)reader["vehicleID"];
                lease1.CustomerID = (int)reader["customerID"];
                lease1.StartDate = Convert.ToDateTime(reader["startdate"]);
                lease1.EndDate = Convert.ToDateTime(reader["endDate"]);
                lease1.Type = (string)reader["type"];
                lease.Add(lease1);

            }
            sqlConnection.Close();
            return lease;
        }

        public List<Lease> listallLease()
        {
            cmd.Parameters.Clear();
            List<Lease> lease = new List<Lease>();

            cmd.CommandText = "select * from Lease ";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Lease lease1 = new Lease();
                lease1.LeaseID = (int)reader["leaseID"];
                lease1.VehicleID = (int)reader["vehicleID"];
                lease1.CustomerID = (int)reader["customerID"];
                lease1.StartDate = Convert.ToDateTime(reader["startdate"]);
                lease1.EndDate = Convert.ToDateTime(reader["endDate"]);
                lease1.Type = (string)reader["type"];
                lease.Add(lease1);
            }
            sqlConnection.Close();
            return lease;
        }



        #endregion
       
        #region Payment Management

        public List<Payment> paymentHistory(Customer customer)
        {
            cmd.Parameters.Clear();
            List<Payment> history = new List<Payment>();
        
            cmd.CommandText = "select * FROM Payment p JOIN Lease l ON p.leaseid = l.leaseid WHERE customerID = @customerID ";
            cmd.Parameters.AddWithValue("@customerID", customer.CustomerID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Payment payment = new Payment();
                payment.PaymentID = (int)reader["paymentID"];
                payment.LeaseID = (int)reader["leaseID"];
                payment.PaymentDate = Convert.ToDateTime(reader["paymentDate"]);
                payment.Amount = (int)reader["amount"];
                history.Add(payment);

            }
            sqlConnection.Close();
            return history;
        }


        public double totalRevenue()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select sum(amount) as total_revenue FROM Payment";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            double revenue = Convert.ToDouble(cmd.ExecuteScalar());
 
            sqlConnection.Close();
            return revenue;

        }

        public int recordPayment(Lease lease)
        {
            cmd.Parameters.Clear();
            double amount = totalLeaseCost(lease.LeaseID);
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Payment(leaseID,paymentDate,amount) VALUES(@idlease,@paymentDate,@amount)";
            cmd.Parameters.AddWithValue("@idlease",lease.LeaseID );
            cmd.Parameters.AddWithValue("@paymentDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@amount",amount);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int addPaymentStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (addPaymentStatus > 0)
            {
                Console.WriteLine("Payment Addition Successful");
            }
            else
            {
                Console.WriteLine("Payment Addition UnSuccessful");
            }
            return addPaymentStatus;
          
        }

        public bool findPaymentByLeaseId(int payment)
        {
            cmd.Parameters.Clear();
            bool exists = false;
            cmd.CommandText = "SELECT COUNT(*) FROM Payment WHERE leaseID = @custid";
            cmd.Parameters.AddWithValue("@custid", payment);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int count = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            exists = count > 0;
            return exists;
        }


      


        #endregion


    }
}

