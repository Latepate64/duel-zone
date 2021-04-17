using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Class for pay cost exceptions.
    /// </summary>
    [System.Serializable]
    public class PayCostException : DuelMastersException
    {
        /// <summary>
        /// Creates a pay cost exception.
        /// </summary>
        public PayCostException()
        {
        }

        /// <summary>
        /// Creates a pay cost exception.
        /// </summary>
        /// <param name="message"></param>
        public PayCostException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a pay cost exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public PayCostException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates a pay cost exception.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PayCostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
