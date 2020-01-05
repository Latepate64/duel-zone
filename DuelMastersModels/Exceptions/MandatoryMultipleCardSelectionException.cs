using System;
using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Represents mandatory multiple card selection exception.
    /// </summary>
    [Serializable]
    public class MandatoryMultipleCardSelectionException : DuelMastersException
    {
        /// <summary>
        /// Creates MandatoryMultipleCardSelectionException.
        /// </summary>
        public MandatoryMultipleCardSelectionException()
        {
        }

        /// <summary>
        /// Creates MandatoryMultipleCardSelectionException.
        /// </summary>
        /// <param name="message"></param>
        public MandatoryMultipleCardSelectionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates MandatoryMultipleCardSelectionException.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public MandatoryMultipleCardSelectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates MandatoryMultipleCardSelectionException.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected MandatoryMultipleCardSelectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}