using System;
using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Represents mandatory creature selection exception.
    /// </summary>
    [Serializable]
    public class MandatoryCreatureSelectionException : DuelMastersException
    {
        /// <summary>
        /// Creates MandatoryCreatureSelectionException.
        /// </summary>
        public MandatoryCreatureSelectionException()
        {
        }

        /// <summary>
        /// Creates MandatoryCreatureSelectionException.
        /// </summary>
        /// <param name="message"></param>
        public MandatoryCreatureSelectionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates MandatoryCreatureSelectionException.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public MandatoryCreatureSelectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates MandatoryCreatureSelectionException.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected MandatoryCreatureSelectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
