using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    [System.Serializable]
    internal class PayCostException : DuelMastersException
    {
        internal PayCostException(string message) : base(message)
        {
        }

        protected PayCostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
