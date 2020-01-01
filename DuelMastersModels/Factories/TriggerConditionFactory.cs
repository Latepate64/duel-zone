using DuelMastersModels.Abilities.Trigger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Factories
{
    internal class TriggerConditionAndRemainingText
    {
        internal TriggerCondition TriggerCondition { get; private set; }
        internal string RemainingText { get; private set; }

        internal TriggerConditionAndRemainingText(TriggerCondition triggerCondition, string remainingText)
        {
            TriggerCondition = triggerCondition;
            RemainingText = remainingText;
        }
    }

    internal static class TriggerConditionFactory
    {
        private static readonly ReadOnlyDictionary<string, Type> _triggerConditionDictionary = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>
        {
            { "When you put this creature into the battle zone,", typeof(WhenYouPutThisCreatureIntoTheBattleZone) },
            { "Whenever a player casts a spell,", typeof(WheneverAPlayerCastsASpell) },
            { "Whenever another creature is put into the battle zone,", typeof(WheneverAnotherCreatureIsPutIntoTheBattleZone) },
        });

        internal static TriggerConditionAndRemainingText ParseTriggerCondition(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            ParsedTypesAndObjects parsed = AbilityTypeFactory.GetTypeFromDictionary(text, _triggerConditionDictionary);
            return parsed?.ParsedType != null
                ? new TriggerConditionAndRemainingText(Activator.CreateInstance(parsed.ParsedType.TypesParsed[0]/*, new Collection<object>(parsedObjects.Values.ToList())*/) as TriggerCondition, parsed.ParsedType.RemainingText)
                : new TriggerConditionAndRemainingText(null, null);
        }

        internal static string GetTextForTriggerCondition(TriggerCondition triggerCondition)
        {
            return _triggerConditionDictionary.First(condition => condition.Value == triggerCondition.GetType()).Key;
        }
    }
}
