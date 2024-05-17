using CRS.main;
using CRS.service;

namespace CRS;

class Program
{
    static void Main(string[] args)
    {
        CarRentalSystemApplication crs = new CarRentalSystemApplication();

        bool running = true;
        while (running)
        {
            running = crs.Run();
        }


    }
}

