using System;
namespace CRS.myexceptions
{
	public class CarNotFoundException : Exception
	{
		public CarNotFoundException()
		{
		}
        public CarNotFoundException(string msg) : base(msg)
        {
        }
        public CarNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}

