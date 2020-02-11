using System;

namespace WebAPI.Common.Exceptions
{
    public class CustomErrorException : Exception
    {
        #region [ Contrutores ]

        public CustomErrorException(string message) : base(message)
        {

        }

        public CustomErrorException(string message, Exception innerException) : base(message, innerException)
        {

        }

        #endregion
    }
}