using System;
namespace CRS.myexceptions
{
	public class LeaseNotFoundException : Exception
	{
		public LeaseNotFoundException()
		{
		}

        public LeaseNotFoundException(string msg) : base(msg)
        {
        }
    }
}

