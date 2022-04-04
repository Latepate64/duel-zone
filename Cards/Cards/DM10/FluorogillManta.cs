using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class FluorogillManta : Creature
    {
        public FluorogillManta() : base("Fluorogill Manta", 6, 1000, Subtype.GelFish, Civilization.Water)
        {
            AddStaticAbilities(new FluorogillMantaEffect());
        }
    }

    class FluorogillMantaEffect : ContinuousEffects.UnblockableEffect
    {
        public FluorogillMantaEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Light, Civilization.Darkness), new Durations.Indefinite(), new CardFilters.BattleZoneCreatureFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new FluorogillMantaEffect();
        }

        public override string ToString()
        {
            return "Your light creatures and darkness creatures can't be blocked.";
        }
    }
}
