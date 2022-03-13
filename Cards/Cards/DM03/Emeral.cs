using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;
using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class Emeral : Creature
    {
        public Emeral() : base("Emeral", 2, 1000, Common.Subtype.CyberLord, Common.Civilization.Water)
        {
            AddAbilities(new PutIntoPlayAbility(new EmeralEffect()));
        }
    }

    class EmeralEffect : OneShotEffect
    {
        public override OneShotEffect Copy()
        {
            return new EmeralEffect();
        }

        public override object Apply(Game game, Ability source)
        {
            var cards = new ShieldAdditionEffect(new CardFilters.OwnersHandCardFilter(), 0, 1, true).Apply(game, source);
            if (cards.Any())
            {
                // If you do, choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
                return new ShieldRecoveryEffect(false).Apply(game, source);
            }
            return cards;
        }

        public override string ToString()
        {
            return "You may add a card from your hand to your shields face down. If you do, choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
        }
    }
}
