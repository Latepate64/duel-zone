using DuelMastersModels.Cards;
using DuelMastersModels.Effects;
//using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.AutomaticActions;
using DuelMastersModels.PlayerActions.OptionalActions;
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
            { "Put the top card of your deck into your mana zone.", typeof(PutTheTopCardOfYourDeckIntoYourManaZone) },
            { "You may draw a card.", typeof(YouMayDrawACard) },
        });

        public static PlayerAction ParseOneShotEffect(string text, Creature creature, Player owner)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            ParsedType parsedType = AbilityTypeFactory.GetTypeFromDictionary(text, _effectDictionary, out Dictionary<string, object> parsedObjects);
            if (parsedType != null)
            {
                return Activator.CreateInstance(parsedType.TypeParsed, owner) as PlayerAction;
                //return Activator.CreateInstance(parsedType.TypeParsed, AbilityTypeFactory.GetInstanceParameters(owner, creature, new Collection<object>(parsedObjects.Values.ToList()))) as PlayerAction;
            }
            else
            {
                return null;
            }
        }
    }
}
