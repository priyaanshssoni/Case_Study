using CRS.dao;
using CRS.model;
using CRS.myexceptions;
using CRS.service;
using NUnit.Framework;

namespace CRTS.Test;
[TestFixture]
public class Class1
{
    
    
    [Test]
    public void TestToAddCar()
    {
        ICarLeaseRepository newcar = new ICarLeaseRepositoryImpl();
        Vehicle newvehicle = new Vehicle() { Make = "GM", Model = "Beat", Year = 2001, DailyRate = 1000, Status = "Available", PassengerCapacity = 5, EngineCapacity = 1500 };
        int newproudct = newcar.addCar(newvehicle);
        Assert.That(1, Is.EqualTo(newproudct));
    }

    
    [Test]
    public void TestToCreateLease()
    {
        ICarLeaseRepository newlease = new ICarLeaseRepositoryImpl();
        Lease lease = new Lease() { VehicleID = 1, CustomerID = 1, StartDate =  Convert.ToDateTime("2024-05-14"), EndDate = Convert.ToDateTime("2024-05-19"), Type="dailylease"  };
        int leasenew = newlease.createLease(lease.VehicleID,lease.CustomerID,lease.StartDate,lease.EndDate,lease.Type) ;
        Assert.That(1, Is.EqualTo(leasenew));
    }
    
    [Test]
    public void TestToRetrieveLease()
    {
        ICarLeaseRepository retrievelease = new ICarLeaseRepositoryImpl();
        var lease = retrievelease.listallLease();
        Assert.That(8, Is.EqualTo(lease.Count));
    }
    


    [Test]
    public void TestToThrowException()
    {
        Customer newcustomer = new Customer() { CustomerID = 999};
        ICarLeaseRepository retrievelease = new ICarLeaseRepositoryImpl();
        Assert.Throws<CustomerrNotFoundException>(() => retrievelease.updateCustomerDetails(newcustomer));
    }


}
