using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM02
{
    class PoisonWorm : Creature
    {
        public PoisonWorm() : base("Poison Worm", 4, 4000, Race.ParasiteWorm, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new PoisonWormEffect());
        }
    }

    class PoisonWormEffect : OneShotEffects.DestroyEffect
    {
        public PoisonWormEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PoisonWormEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your creatures that has power 3000 or less.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(GetSourceAbility(game).Controller).Where(x => x.Power <= 3000);
        }
    }
}
