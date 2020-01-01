using System.Collections.Generic;

namespace DuelMastersModels.Factories
{
    internal class ParsedTypesAndObjects
    {
        internal ParsedType ParsedType { get; private set; }
        internal Dictionary<string, object> Objects { get; private set; }

        internal ParsedTypesAndObjects(ParsedType parsedType, Dictionary<string, object> parsedObjects)
        {
            ParsedType = parsedType;
            Objects = parsedObjects;
        }
    }
}
