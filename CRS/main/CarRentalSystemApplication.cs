using System;
using CRS.service;

namespace CRS.main
{
	public class CarRentalSystemApplication
	{
        readonly ICarLeaseRepositoryService _ICarLeaseRepositoryService;
        public CarRentalSystemApplication()
        {
            _ICarLeaseRepositoryService = new ICarLeaseRepositoryServiceImpl();




        }

        public bool Run()
        {
            bool exit = false;
            while (!exit)
            {
            mainmenu:


                Console.WriteLine("    WELCOME TO CAR RENTAL SYSTEM");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine("Please choose a service:");
                Console.WriteLine();
                Console.WriteLine("  1) Customer Management");
                Console.WriteLine("  2) Car Management");
                Console.WriteLine("  3) Lease Management");
                Console.WriteLine("  4) Payment Handling");
                Console.WriteLine("  0) Exit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                Console.WriteLine();

                int userInput;
                if (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (userInput)
                {
                    case 1:


                        Console.WriteLine("         CUSTOMER MANAGEMENT CONSOLE");
                        Console.WriteLine("========================================");
                        Console.WriteLine();
                        Console.WriteLine("Please choose an option:");
                        Console.WriteLine();
                        Console.WriteLine("  1) Add New Customer");
                        Console.WriteLine("  2) Update Customer Details");
                        Console.WriteLine("  3) Remove Customer");
                        Console.WriteLine("  4) List All Customers");
                        Console.WriteLine("  5) Find Customer Details By Id");
                        Console.WriteLine("  0) Go Back to Main Menu");
                        Console.WriteLine();
                        Console.Write("Enter your choice: ");


                        int u1;
                        if (!int.TryParse(Console.ReadLine(), out u1))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }

                        switch (u1)
                        {
                            case 1:
                                _ICarLeaseRepositoryService.addCustomer();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 2:
                                _ICarLeaseRepositoryService.updateCustomerDetails();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 3:
                                _ICarLeaseRepositoryService.removeCustomer();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 4:
                                _ICarLeaseRepositoryService.listCustomers();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 5:
                                _ICarLeaseRepositoryService.findCustomerById();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                continue;
                            case 0:
                                goto mainmenu;
                            default:
                                Console.WriteLine("ENTER CORRECT DETAILS ");
                                break;
                        }

                        break;

                    case 2:


                        Console.WriteLine("           CAR MANAGEMENT CONSOLE");
                        Console.WriteLine("========================================");
                        Console.WriteLine();
                        Console.WriteLine("Please choose an option:");
                        Console.WriteLine();
                        Console.WriteLine("  1) Add New Car");
                        Console.WriteLine("  2) Remove Car");
                        Console.WriteLine("  3) List Rented Cars");
                        Console.WriteLine("  4) List Available Cars");
                        Console.WriteLine("  5) Find Car Information By Id");
                        Console.WriteLine("  0) Go Back to Main Menu");
                        Console.WriteLine();
                        Console.Write("Enter your choice: ");


                        int u2;
                        if (!int.TryParse(Console.ReadLine(), out u2))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }

                        switch (u2)
                        {
                            case 1:

                                _ICarLeaseRepositoryService.addCar();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 2:
                                _ICarLeaseRepositoryService.removeCar();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 3:
                                _ICarLeaseRepositoryService.listRentedCars();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();

                                break;
                            case 4:
                                _ICarLeaseRepositoryService.listAvailableCars();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;

                            case 5:
                                _ICarLeaseRepositoryService.findCarById();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;

                            case 0:
                                goto mainmenu;

                            default:
                                Console.WriteLine("ENTER CORRECT DETAILS ");
                                Console.ReadLine();
                                break;
                        }

                        break;

                    case 3:

                        Console.WriteLine("           LEASE MANAGEMENT CONSOLE");
                        Console.WriteLine("========================================");
                        Console.WriteLine();
                        Console.WriteLine("Please choose an option:");
                        Console.WriteLine();
                        Console.WriteLine("  1) Create New Lease");
                        Console.WriteLine("  2) Return Car");
                        Console.WriteLine("  3) List Active Leases");
                        Console.WriteLine("  4) List Past Leases");
                        Console.WriteLine("  5) Calculate Lease Cost");
                        Console.WriteLine("  0) Go Back to Main Menu");
                        Console.WriteLine();
                        Console.Write("Enter your choice: ");



                        int u3;
                        if (!int.TryParse(Console.ReadLine(), out u3))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }

                        switch (u3)
                        {
                            case 1:
                                _ICarLeaseRepositoryService.createLease();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 2:
                                _ICarLeaseRepositoryService.returnCar();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;

                            case 3:
                                _ICarLeaseRepositoryService.listActiveLeases();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;

                            case 4:
                                _ICarLeaseRepositoryService.listLeaseHistory();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;

                            case 5:
                                _ICarLeaseRepositoryService.calculatetotalleaseCost();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 0:
                                goto mainmenu;


                            default:
                                Console.WriteLine("ENTER CORRECT DETAILS ");
                                Console.ReadLine();
                                break;
                        }


                        break;

                    case 4:


                        Console.WriteLine("        PAYMENT HANDLING CONSOLE");
                        Console.WriteLine("========================================");
                        Console.WriteLine();
                        Console.WriteLine("Please choose an option:");
                        Console.WriteLine();
                        Console.WriteLine("  1) Record New Payment");
                        Console.WriteLine("  2) Retrieve Payment History For Customer");
                        Console.WriteLine("  3) Calculate Total Revenue");
                        Console.WriteLine("  0) Go Back to Main Menu");
                        Console.WriteLine();
                        Console.Write("Enter your choice: ");




                        int u4;
                        if (!int.TryParse(Console.ReadLine(), out u4))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }

                        switch (u4)
                        {
                            case 1:
                                _ICarLeaseRepositoryService.recordPayment();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 2:
                                _ICarLeaseRepositoryService.paymentHistory();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 3:
                                _ICarLeaseRepositoryService.totalRevenue();
                                Console.WriteLine("Press Any Key To Go Back To Main Menu");
                                Console.ReadLine();
                                break;
                            case 0:
                                goto mainmenu;



                            default:
                                Console.WriteLine("ENTER CORRECT DETAILS ");
                                break;
                        }
                        break;

                    case 0:
                        exit = true;
                        Console.WriteLine("Exited");
                        return false;

                    default:
                        Console.WriteLine("ENTER CORRECT INPUT ");
                        break;
                }







            }
            return true;
        }



    }
}

