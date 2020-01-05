using System.Runtime.Serialization;

namespace DuelMastersModels.Exceptions
{
    /// <summary>
    /// Represents an error when one-shot effect cannot be parsed for creature.
    /// </summary>
    [System.Serializable]
    internal class ParseOneShotEffectForCreatureException : ParseException
    {
        internal ParseOneShotEffectForCreatureException(string message) : base(message)
        {
        }

        protected ParseOneShotEffectForCreatureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}