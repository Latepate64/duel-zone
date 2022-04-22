using Cards.ContinuousEffects;
using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cards
{
    public static class CardFactory
    {
        static public Card Create(string name)
        {
            string set = "DM08"; //TODO: improve
            return Activator.CreateInstance(null, $"Cards.Cards.{set}.{ToPascalCase(name)}").Unwrap() as Card;
        }

        public static string ToPascalCase(string original)
        {
            // replace white spaces with undescore, then replace all invalid chars with empty string
            var pascalCase = new Regex("[^_a-zA-Z0-9]").Replace(new Regex(@"(?<=\s)").Replace(original, "_"), string.Empty)
                // split by underscores
                .Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                // set first letter to uppercase
                .Select(w => new Regex("^[a-z]").Replace(w, m => m.Value.ToUpper()))
                // replace second and all following upper case letters to lower if there is no next lower (ABC -> Abc)
                .Select(w => new Regex("(?<=[A-Z])[A-Z0-9]+$").Replace(w, m => m.Value.ToLower()))
                // set upper case the first lower case following a number (Ab9cd -> Ab9Cd)
                .Select(w => new Regex("(?<=[0-9])[a-z]").Replace(w, m => m.Value.ToUpper()))
                // lower second and next upper case letters except the last if it follows by any lower (ABcDEf -> AbcDef)
                .Select(w => new Regex("(?<=[A-Z])[A-Z]+?((?=[A-Z][a-z])|(?=[0-9]))").Replace(w, m => m.Value.ToLower()));
            return string.Concat(pascalCase);
        }

        static public IEnumerable<Card> CreateAll()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace != null && t.Namespace.StartsWith("Cards.Cards") && !t.Name.EndsWith("Effect") && !t.Name.EndsWith("Ability") && !t.Name.EndsWith("Filter") && !t.Name.EndsWith("Event") && !t.Name.EndsWith("Choice")).Select(x => Activator.CreateInstance(x)).OfType<Card>();
        }

        static public IEnumerable<IEffect> CreateEffects()
        {
            var types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace != null && t.Name.EndsWith("Effect"));
            return types.Select(x => CreateEffect(x)).Where(x => x != null);
        }

        static private IEffect CreateEffect(Type type)
        {
            var interfaces = type.GetInterfaces();
            if (type.IsAbstract || interfaces.Contains(typeof(IExpirable)) || interfaces.Contains(typeof(ICardAffectable)) || type.BaseType == typeof(AddAbilitiesUntilEndOfTurnEffect) || type.BaseType == typeof(UntilEndOfTurnEffect) || type == typeof(SurvivorEffect) || type == typeof(TapAbilityAddingEffect) || type == typeof(TurboRushEffect) || type == typeof(WaveStrikerEffect))
            {
                return null;
            }
            else
            {
                var arguments = new List<object>();
                if (interfaces.Contains(typeof(IPowerable)))
                {
                    arguments.Add(1000);
                }
                if (interfaces.Contains(typeof(IRaceable)) || interfaces.Contains(typeof(IMultiRaceable)))
                {
                    arguments.Add(Race.AngelCommand);
                }
                if (interfaces.Contains(typeof(ICivilizationable)) || interfaces.Contains(typeof(IMultiCivilizationable)))
                {
                    arguments.Add(Civilization.Light);
                }
                if (arguments.Any())
                {
                    return Activator.CreateInstance(type, arguments.ToArray()) as IEffect;
                }
                else
                {
                    return Activator.CreateInstance(type) as IEffect;
                }
            }
        }
    }
}
