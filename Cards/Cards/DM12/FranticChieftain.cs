using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class FranticChieftain : Creature
    {
        public FranticChieftain() : base("Frantic Chieftain", 2, 2000, Race.Merfolk, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new FranticChieftainEffect());
        }
    }

    class FranticChieftainEffect : OneShotEffects.BounceEffect
    {
        public FranticChieftainEffect() : base(1, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new FranticChieftainEffect();
        }

        public override string ToString()
        {
            return "Return one of your creatures that costs 4 or less from the battle zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Ability.ControllerPlayer.Id).Where(x => x.ManaCost <= 4);
        }
    }
}
