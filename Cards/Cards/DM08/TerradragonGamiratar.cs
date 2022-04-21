using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM08
{
    class TerradragonGamiratar : Creature
    {
        public TerradragonGamiratar() : base("Terradragon Gamiratar", 4, 6000, Race.EarthDragon, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TerradragonGamiratarEffect());
            AddDoubleBreakerAbility();
        }
    }

    class TerradragonGamiratarEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public TerradragonGamiratarEffect() : base(0, 1, false, ZoneType.Hand, ZoneType.BattleZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new TerradragonGamiratarEffect();
        }

        public override string ToString()
        {
            return "Your opponent may choose a creature in his hand and put it into the battle zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return GetOpponent(game).Hand.Creatures;
        }
    }
}
