using System;
using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Represents mandatory card selection exception.
    /// </summary>
    [Serializable]
    public class MandatoryCardSelectionException : DuelMastersException
    {
        /// <summary>
        /// Creates MandatoryCardSelectionException.
        /// </summary>
        public MandatoryCardSelectionException()
        {
        }

        /// <summary>
        /// Creates MandatoryCardSelectionException.
        /// </summary>
        /// <param name="message"></param>
        public MandatoryCardSelectionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates MandatoryCardSelectionException.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public MandatoryCardSelectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates MandatoryCardSelectionException.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected MandatoryCardSelectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
