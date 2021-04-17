using System;
using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Represents optional creature selection exception.
    /// </summary>
    [Serializable]
    public class OptionalCreatureSelectionException : DuelMastersException
    {
        /// <summary>
        /// Creates OptionalCreatureSelectionException.
        /// </summary>
        public OptionalCreatureSelectionException()
        {
        }

        /// <summary>
        /// Creates OptionalCreatureSelectionException.
        /// </summary>
        /// <param name="message"></param>
        public OptionalCreatureSelectionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates OptionalCreatureSelectionException.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public OptionalCreatureSelectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates OptionalCreatureSelectionException.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected OptionalCreatureSelectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}