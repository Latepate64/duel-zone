using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Factories
{
    public class TriggerConditionAndRemainingText
    {
        public TriggerCondition TriggerCondition { get; private set; }
        public string RemainingText { get; private set; }

        public TriggerConditionAndRemainingText(TriggerCondition triggerCondition, string remainingText)
        {
            TriggerCondition = triggerCondition;
            RemainingText = remainingText;
        }
    }

    public static class TriggerConditionFactory
    {
        private static readonly ReadOnlyDictionary<string, Type> _triggerConditionDictionary = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>
        {
            { "When you put this creature into the battle zone,", typeof(WhenYouPutThisCreatureIntoTheBattleZone) },
            { "Whenever another creature is put into the battle zone,", typeof(WheneverAnotherCreatureIsPutIntoTheBattleZone) },
        });

        public static TriggerConditionAndRemainingText ParseTriggerCondition(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            ParsedTypesAndObjects parsed = AbilityTypeFactory.GetTypeFromDictionary(text, _triggerConditionDictionary);
            ParsedType parsedType = parsed.ParsedType;
            return parsedType != null
                ? new TriggerConditionAndRemainingText(Activator.CreateInstance(parsedType.TypesParsed[0]/*, new Collection<object>(parsedObjects.Values.ToList())*/) as TriggerCondition, parsedType.RemainingText)
                : new TriggerConditionAndRemainingText(null, null);
        }

        public static string GetTextForTriggerCondition(TriggerCondition triggerCondition)
        {
            return _triggerConditionDictionary.First(condition => condition.Value == triggerCondition.GetType()).Key;
        }
    }
}
