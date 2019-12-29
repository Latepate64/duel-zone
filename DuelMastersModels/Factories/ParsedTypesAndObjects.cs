using System.Collections.Generic;

namespace DuelMastersModels.Factories
{
    public class ParsedTypesAndObjects
    {
        public ParsedType ParsedType { get; private set; }
        public Dictionary<string, object> Objects { get; private set; }

        public ParsedTypesAndObjects(ParsedType parsedType, Dictionary<string, object> parsedObjects)
        {
            ParsedType = parsedType;
            Objects = parsedObjects;
        }
    }
}
