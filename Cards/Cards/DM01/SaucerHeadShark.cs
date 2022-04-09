using Cards.CardFilters;
using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM01
{
    class SaucerHeadShark : Creature
    {
        public SaucerHeadShark() : base("Saucer-Head Shark", 5, 3000, Subtype.GelFish, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new SaucerHeadSharkEffect());
        }
    }

    class SaucerHeadSharkEffect : BounceAreaOfEffect
    {
        public SaucerHeadSharkEffect() : base(new BattleZoneMaxPowerCreatureFilter(2000))
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SaucerHeadSharkEffect();
        }

        public override string ToString()
        {
            return "Return each creature in the battle zone that has power 2000 or less to its owner's hand.";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.Creatures.Where(x => x.Power <= 2000);
        }
    }
}
