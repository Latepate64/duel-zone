using System;
using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Represents multiple card selection exception.
    /// </summary>
    [Serializable]
    public class MultipleCardSelectionException : DuelMastersException
    {
        /// <summary>
        /// Creates MultipleCardSelectionException.
        /// </summary>
        public MultipleCardSelectionException()
        {
        }

        /// <summary>
        /// Creates MultipleCardSelectionException.
        /// </summary>
        /// <param name="message"></param>
        public MultipleCardSelectionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates MultipleCardSelectionException.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public MultipleCardSelectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates MultipleCardSelectionException.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected MultipleCardSelectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
