using Common;

namespace Cards.Cards.DM03
{
    class LegendaryBynor : EvolutionCreature
    {
        public LegendaryBynor() : base("Legendary Bynor", 6, 8000, Subtype.Leviathan, Civilization.Water)
        {
            AddAbilities(new Engine.Abilities.StaticAbility(new Engine.ContinuousEffects.UnblockableEffect(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Water), new CardFilters.BattleZoneCreatureFilter())));
        }
    }
}
