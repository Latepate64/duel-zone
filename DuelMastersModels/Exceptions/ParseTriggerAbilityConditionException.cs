using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    [System.Serializable]
    internal class ParseTriggerAbilityConditionException : ParseException
    {
        internal ParseTriggerAbilityConditionException(string message) : base(message)
        {
        }
        protected ParseTriggerAbilityConditionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}