using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM03
{
    class Emeral : Creature
    {
        public Emeral() : base("Emeral", 2, 1000, Common.Subtype.CyberLord, Common.Civilization.Water)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new EmeralEffect()));
        }
    }

    class EmeralEffect : OneShotEffect
    {
        public override IOneShotEffect Copy()
        {
            return new EmeralEffect();
        }

        public override object Apply(IGame game, IAbility source)
        {
            var cards = new EmeralShieldAdditionEffect().Apply(game, source);
            if (cards.Any())
            {
                return new ShieldRecoveryCannotUseShieldTriggerEffect().Apply(game, source);
            }
            return cards;
        }

        public override string ToString()
        {
            return "You may add a card from your hand to your shields face down. If you do, choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
        }
    }

    class EmeralShieldAdditionEffect : ShieldAdditionEffect
    {
        public EmeralShieldAdditionEffect() : base(new CardFilters.OwnersHandCardFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new EmeralShieldAdditionEffect();
        }

        public override string ToString()
        {
            return "You may add a card from your hand to your shields face down.";
        }
    }
}
