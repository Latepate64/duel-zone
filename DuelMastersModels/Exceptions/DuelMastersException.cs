using System;
using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Class for parsing exceptions.
    /// </summary>
    [Serializable]
    public abstract class DuelMastersException : Exception
    {
        /// <summary>
        /// Creates a parse exception.
        /// </summary>
        protected DuelMastersException()
        {
        }

        /// <summary>
        /// Creates a parse exception.
        /// </summary>
        /// <param name="message"></param>
        protected DuelMastersException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a parse exception. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected DuelMastersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates a parse exception.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DuelMastersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
