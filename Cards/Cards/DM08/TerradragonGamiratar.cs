using Common;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    class TerradragonGamiratar : Creature
    {
        public TerradragonGamiratar() : base("Terradragon Gamiratar", 4, 6000, Subtype.EarthDragon, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TerradragonGamiratarEffect());
            AddDoubleBreakerAbility();
        }
    }

    class TerradragonGamiratarEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public TerradragonGamiratarEffect() : base(new CardFilters.OpponentsHandCreatureFilter(), 0, 1, false, ZoneType.Hand, ZoneType.BattleZone)
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
    }
}
