using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Factories
{
    public static class TriggerConditionFactory
    {
        private static readonly ReadOnlyDictionary<string, Type> _triggerConditionDictionary = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>
        {
            { "When you put this creature into the battle zone,", typeof(WhenYouPutThisCreatureIntoTheBattleZone) },
            { "Whenever a player casts a spell,", typeof(WheneverAPlayerCastsASpell) },
            { "Whenever another creature is put into the battle zone,", typeof(WheneverAnotherCreatureIsPutIntoTheBattleZone) },
        });

        public static TriggerCondition ParseTriggerCondition(string text, Creature creature, Player owner, out string remainingText)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            ParsedType parsedType = AbilityTypeFactory.GetTypeFromDictionary(text, _triggerConditionDictionary, out Dictionary<string, object> parsedObjects);
            if (parsedType != null)
            {
                remainingText = parsedType.RemainingText;
                return Activator.CreateInstance(parsedType.TypesParsed[0]/*, new Collection<object>(parsedObjects.Values.ToList())*/) as TriggerCondition;
            }
            else
            {
                remainingText = null;
                return null;
            }
        }

        public static string GetTextForTriggerCondition(TriggerCondition triggerCondition)
        {
            return _triggerConditionDictionary.First(condition => condition.Value == triggerCondition.GetType()).Key;
        }
    }
}
