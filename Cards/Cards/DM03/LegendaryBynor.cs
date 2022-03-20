using Common;

namespace Cards.Cards.DM03
{
    class LegendaryBynor : EvolutionCreature
    {
        public LegendaryBynor() : base("Legendary Bynor", 6, 8000, Subtype.Leviathan, Civilization.Water)
        {
            AddAbilities(new LegendaryBynorAbility());
        }
    }

    class LegendaryBynorAbility : Engine.Abilities.StaticAbility
    {
        public LegendaryBynorAbility() : base(new Engine.ContinuousEffects.UnblockableEffect(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Water), new CardFilters.BattleZoneCreatureFilter()))
        {
        }

        public override string ToString()
        {
            return "Your other water creatures in the battle zone can't be blocked.";
        }
    }
}
