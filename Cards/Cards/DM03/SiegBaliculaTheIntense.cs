using Common;

namespace Cards.Cards.DM03
{
    class SiegBaliculaTheIntense : EvolutionCreature
    {
        public SiegBaliculaTheIntense() : base("Sieg Balicula, the Intense", 3, 5000, Subtype.Initiate, Civilization.Light)
        {
            AddAbilities(new SiegBaliculaTheIntenseAbility());
        }
    }

    class SiegBaliculaTheIntenseAbility : Engine.Abilities.StaticAbility
    {
        public SiegBaliculaTheIntenseAbility() : base(new SiegBaliculaTheIntenseEffect())
        {
        }
    }

    class SiegBaliculaTheIntenseEffect : Engine.ContinuousEffects.BlockerEffect
    {
        public SiegBaliculaTheIntenseEffect() : base(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Light), new CardFilters.OpponentsBattleZoneCreatureFilter()) { }

        public override string ToString()
        {
            return "Each of your other light creatures in the battle zone has \"blocker.\"";
        }
    }
}
