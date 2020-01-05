using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Factories
{
    internal static class EffectFactory
    {
        private static readonly ReadOnlyDictionary<string, Type> _effectDictionary = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>
        {
            { "Put the top card of your deck into your mana zone.", typeof(PutTheTopCardOfYourDeckIntoYourManaZoneEffect) },
            { "Tap all your opponent's creatures in the battle zone.", typeof(TapAllYourOpponentsCreaturesInTheBattleZoneEffect) },
            #region You may
            { "You may add a card from your hand to your shields face down. If you do, choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.", typeof(YouMayAddACardFromYourHandToYourShieldsFaceDownIfYouDoChooseOneOfYourShieldsAndPutItIntoYourHandYouCannotUseTheShieldTriggerAbilityOfThatShieldEffect) },
            { "You may choose a creature in the battle zone and put it into its owner's mana zone. If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.", typeof(SoulSwapEffect/*YouMayChooseACreatureInTheBattleZoneAndPutItIntoItsOwnersManaZoneIfYouDoChooseANonEvolutionCreatureInThatPlayersManaZoneThatCostsTheSameAsOrLessThanTheNumberOfCardsInThatManaZoneThatPlayerPutsThatCreatureIntoTheBattleZone*/) },
            { "You may choose a creature in the battle zone and return it to its owner's hand.", typeof(YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect) },
            { "You may draw a card.", typeof(YouMayDrawACardEffect) },
            #endregion You may
        });

        private static readonly ReadOnlyDictionary<string, Type[]> _effectsDictionary = new ReadOnlyDictionary<string, Type[]>(new Dictionary<string, Type[]>
        {
            { "Put the top card of your deck into your mana zone. Then add the top card of your deck to your shields face down.", new Type[] { typeof(PutTheTopCardOfYourDeckIntoYourManaZoneEffect), typeof(AddTheTopCardOfYourDeckToYourShieldsFaceDownEffect) } },
        });

        internal static ReadOnlyOneShotEffectCollection ParseOneShotEffect(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }
            ParsedTypesAndObjects parsed = AbilityTypeFactory.GetTypeFromDictionary(text, _effectDictionary);
            if (parsed?.ParsedType != null && string.IsNullOrEmpty(parsed.ParsedType.RemainingText))
            {
                OneShotEffect oneShotEffect = Activator.CreateInstance(parsed.ParsedType.TypesParsed[0]) as OneShotEffect;
                return new ReadOnlyOneShotEffectCollection(oneShotEffect);
            }
            else
            {
                return TryParseMultipleEffects(text);
            }
        }

        /*
        internal static string GetTextForEffects(ReadOnlyOneShotEffectCollection oneShotEffects)
        {
            if (oneShotEffects.Count == 1)
            {
                OneShotEffect oneShotEffect = oneShotEffects.First();
                if (oneShotEffect is OneShotEffectForCreature oneShotEffectForCreature)
                {
                    string text = _creatureEffectDictionary.First(effect => effect.Value == oneShotEffectForCreature.GetType()).Key;
                    if (oneShotEffectForCreature is ThisCreatureGetsXPowerUntilTheEndOfTheTurn thisCreatureGetsXPowerUntilTheEndOfTheTurn)
                    {
                        text = text.Replace("$plusinteger", string.Concat('+', thisCreatureGetsXPowerUntilTheEndOfTheTurn.Power));
                    }
                    return text;
                }
                else
                {
                    return _effectDictionary.First(effect => effect.Value == oneShotEffect.GetType()).Key;
                }
            }
            else if (oneShotEffects.Count > 1)
            {
                Type[] types = oneShotEffects.Select(e => e.GetType()).ToArray();
                return _effectsDictionary.First(effects => Enumerable.SequenceEqual(effects.Value, types)).Key;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        */

        private static ReadOnlyOneShotEffectCollection TryParseMultipleEffects(string text)
        {
            ParsedTypesAndObjects parsed = AbilityTypeFactory.GetTypeFromDictionary(text, _effectsDictionary);
            if (parsed?.ParsedType != null)
            {
                return new ReadOnlyOneShotEffectCollection(parsed.ParsedType.TypesParsed.Select(type => Activator.CreateInstance(type) as OneShotEffect));
            }
            else
            {
                throw new ParseOneShotEffectException(text);
            }
        }
    }
}
