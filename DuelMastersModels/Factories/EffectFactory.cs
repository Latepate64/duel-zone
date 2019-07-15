using DuelMastersModels.Cards;
using DuelMastersModels.Effects;
using DuelMastersModels.Effects.OneShotEffects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Factories
{
    public static class EffectFactory
    {
        private static readonly ReadOnlyDictionary<string, Type> _effectDictionary = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>
        {
            { "Put the top card of your deck into your mana zone.", typeof(PutTheTopCardOfYourDeckIntoYourManaZoneEffect) },
            //{ "Put the top card of your deck into your mana zone. Then add the top card of your deck to your shields face down.", typeof(PutTheTopCardOfYourDeckIntoYourManaZoneThenAddTheTopCardOfYourDeckToYourShieldsFaceDownEffect) },
            { "You may choose a creature in the battle zone and return it to its owner's hand.", typeof(YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect) },
            { "You may draw a card.", typeof(YouMayDrawACardEffect) },
        });

        private static readonly ReadOnlyDictionary<string, Type[]> _effectsDictionary = new ReadOnlyDictionary<string, Type[]>(new Dictionary<string, Type[]>
        {
            { "Put the top card of your deck into your mana zone. Then add the top card of your deck to your shields face down.", new Type[] { typeof(PutTheTopCardOfYourDeckIntoYourManaZoneEffect), typeof(AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect) } },
        });

        public static Collection<OneShotEffect> ParseOneShotEffect(string text, Creature creature, Player owner)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            ParsedType parsedType = AbilityTypeFactory.GetTypeFromDictionary(text, _effectDictionary, out Dictionary<string, object> parsedObjects);
            if (parsedType != null && string.IsNullOrEmpty(parsedType.RemainingText))
            {
                OneShotEffect oneShotEffect = Activator.CreateInstance(parsedType.TypesParsed[0]) as OneShotEffect;
                return new Collection<OneShotEffect>() { oneShotEffect };
                //return Activator.CreateInstance(parsedType.TypeParsed, AbilityTypeFactory.GetInstanceParameters(owner, creature, new Collection<object>(parsedObjects.Values.ToList()))) as PlayerAction;
            }
            else
            {
                return TryParseMultipleEffects(text);
            }
        }

        private static Collection<OneShotEffect> TryParseMultipleEffects(string text)
        {
            ParsedType parsedType = AbilityTypeFactory.GetTypeFromDictionary(text, _effectsDictionary, out Dictionary<string, object> parsedObjects);
            if (parsedType != null)
            {
                Collection<OneShotEffect> oneShotEffects = new Collection<OneShotEffect>();
                foreach (Type type in parsedType.TypesParsed)
                {
                    OneShotEffect oneShotEffect = Activator.CreateInstance(type) as OneShotEffect;
                    oneShotEffects.Add(oneShotEffect);
                }
                return oneShotEffects;
            }
            else
            {
                return null;
            }
        }
    }
}
