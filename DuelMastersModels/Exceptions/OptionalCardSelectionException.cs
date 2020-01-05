using System;
using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Represents optional card selection exception.
    /// </summary>
    [Serializable]
    public class OptionalCardSelectionException : DuelMastersException
    {
        /// <summary>
        /// Creates OptionalCardSelectionException.
        /// </summary>
        public OptionalCardSelectionException()
        {
        }

        /// <summary>
        /// Creates OptionalCardSelectionException.
        /// </summary>
        /// <param name="message"></param>
        public OptionalCardSelectionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates OptionalCardSelectionException.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public OptionalCardSelectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates OptionalCardSelectionException.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected OptionalCardSelectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}