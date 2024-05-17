using System;
namespace CRS.myexceptions
{
	public class InvalidDataFormatException : Exception
	{
		public InvalidDataFormatException()
		{
		}
        public InvalidDataFormatException(string msg): base(msg)
        {
        }
    }
}

