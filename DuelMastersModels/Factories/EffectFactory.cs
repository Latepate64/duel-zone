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

        private static readonly ReadOnlyDictionary<string, Type> _creatureEffectDictionary = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>
        {
            { "This creature gets $plusinteger power until the end of the turn.", typeof(ThisCreatureGetsXPowerUntilTheEndOfTheTurn) },
            { "This creature gets $plusinteger power until the end of the turn. (Do what the spell says before this creature gets the extra power.)", typeof(ThisCreatureGetsXPowerUntilTheEndOfTheTurn) },
        });

        public static Collection<OneShotEffect> ParseOneShotEffect(string text, Player owner)
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

        public static OneShotEffectForCreature ParseOneShotEffectForCreature(string text, Creature creature)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            ParsedType parsedType = AbilityTypeFactory.GetTypeFromDictionary(text, _creatureEffectDictionary, out Dictionary<string, object> parsedObjects);
            if (parsedType != null && string.IsNullOrEmpty(parsedType.RemainingText))
            {
                return Activator.CreateInstance(parsedType.TypesParsed[0], AbilityTypeFactory.GetInstanceParameters(creature, new Collection<object>(parsedObjects.Values.ToList()))) as OneShotEffectForCreature;
            }
            else
            {
                return null;
            }
        }

        public static string GetTextForEffects(Collection<OneShotEffect> oneShotEffects)
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

        private static Collection<OneShotEffect> TryParseMultipleEffects(string text)
        {
            ParsedType parsedType = AbilityTypeFactory.GetTypeFromDictionary(text, _effectsDictionary, out Dictionary<string, object> parsedObjects);
            if (parsedType != null)
            {
                Collection<OneShotEffect> oneShotEffects = new Collection<OneShotEffect>();
                foreach (Type type in parsedType.TypesParsed)
                {
                    oneShotEffects.Add(Activator.CreateInstance(type) as OneShotEffect);
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
