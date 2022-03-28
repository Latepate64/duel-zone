using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM03
{
    class TrenchdiveShark : Creature
    {
        public TrenchdiveShark() : base("Trenchdive Shark", 7, 5000, Subtype.GelFish, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TrenchdiveSharkEffect());
        }
    }

    class TrenchdiveSharkEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = new TrenchdiveSharkShieldAdditionEffect().Apply(game, source);
            if (cards.Any())
            {
                return new ShieldRecoveryCannotUseShieldTriggerEffect(cards.Count()).Apply(game, source);
            }
            return cards;
        }

        public override IOneShotEffect Copy()
        {
            return new TrenchdiveSharkEffect();
        }

        public override string ToString()
        {
            return "You may add up to 2 cards from your hand to your shields face down. If you do, choose the same number of your shields and put them into your hand. You can't use the \"shield trigger\" ability of those shields.";
        }
    }

    class TrenchdiveSharkShieldAdditionEffect : ShieldAdditionEffect
    {
        public TrenchdiveSharkShieldAdditionEffect() : base(new CardFilters.OwnersHandCardFilter(), 0, 2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new TrenchdiveSharkShieldAdditionEffect();
        }

        public override string ToString()
        {
            return "You may add up to 2 cards from your hand to your shields face down.";
        }
    }
}
