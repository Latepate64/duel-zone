using System;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Factories
{
    internal class ParsedType
    {
        internal Collection<Type> TypesParsed { get; private set; }
        internal string RemainingText { get; private set; }

        internal ParsedType(Type type, string remainingText)
        {
            TypesParsed = new Collection<Type>() { type };
            RemainingText = remainingText;
        }

        internal ParsedType(Type[] types, string remainingText)
        {
            TypesParsed = new Collection<Type>(types);
            RemainingText = remainingText;
        }
    }
}
