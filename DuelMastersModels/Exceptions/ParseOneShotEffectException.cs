using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Represents an error when one-shot effect cannot be parsed.
    /// </summary>
    [System.Serializable]
    internal class ParseOneShotEffectException : ParseException
    {
        internal ParseOneShotEffectException(string message) : base(message)
        {
        }

        protected ParseOneShotEffectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}