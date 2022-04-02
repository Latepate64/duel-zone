using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class TerradragonAnristVhal : Creature
    {
        public TerradragonAnristVhal() : base("Terradragon Anrist Vhal", 6, 0, Subtype.EarthDragon, Civilization.Nature)
        {
            AddStaticAbilities(new TerradragonAnristVhalEffect(), new ContinuousEffects.PoweredDoubleBreaker());
        }
    }

    class TerradragonAnristVhalEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public TerradragonAnristVhalEffect() : base(2000, new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Nature))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TerradragonAnristVhalEffect();
        }

        public override string ToString()
        {
            return "This creature gets +2000 power for each of your other nature creatures in the battle zone.";
        }
    }
}
