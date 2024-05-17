using System;
namespace CRS.myexceptions
{
	public class CarAvailibilityException : Exception
	{
		public CarAvailibilityException(string msg): base(msg)
		{
		}
        public CarAvailibilityException( )
		{
        }
    }
}

