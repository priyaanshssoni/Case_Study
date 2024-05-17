using System;
namespace CRS.myexceptions
{
	public class CustomerrNotFoundException : Exception
	{
		public CustomerrNotFoundException()
		{
		}


        public CustomerrNotFoundException(string msg) : base(msg)
        {
        }
        
    }
}

