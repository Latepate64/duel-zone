using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class HourglassMutant : Creature
    {
        public HourglassMutant() : base("Hourglass Mutant", 3, 2000, Subtype.Hedrian, Civilization.Darkness)
        {
            AddStaticAbilities(new HourglassMutantEffect());
        }
    }

    class HourglassMutantEffect : SlayerEffect
    {
        public HourglassMutantEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Water, Civilization.Fire), new CardFilters.BattleZoneCreatureFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new HourglassMutantEffect();
        }

        public override string ToString()
        {
            return "Each of your water creatures and fire creatures in the battle zone has \"slayer.\"";
        }
    }
}
