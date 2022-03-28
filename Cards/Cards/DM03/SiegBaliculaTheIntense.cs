using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class SiegBaliculaTheIntense : EvolutionCreature
    {
        public SiegBaliculaTheIntense() : base("Sieg Balicula, the Intense", 3, 5000, Subtype.Initiate, Civilization.Light)
        {
            AddStaticAbilities(new SiegBaliculaTheIntenseEffect());
        }
    }

    class SiegBaliculaTheIntenseEffect : BlockerEffect
    {
        public SiegBaliculaTheIntenseEffect() : base(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Light), new CardFilters.OpponentsBattleZoneCreatureFilter(), new Durations.Indefinite()) { }

        public override IContinuousEffect Copy()
        {
            return new SiegBaliculaTheIntenseEffect();
        }

        public override string ToString()
        {
            return "Each of your other light creatures in the battle zone has \"blocker.\"";
        }
    }
}
