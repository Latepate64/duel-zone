using Engine.Abilities;

namespace Cards.DM06
{
    sealed class CharmiliaTheEnticer : Creature
    {
        public CharmiliaTheEnticer() : base("Charmilia, the Enticer", 4, 3000, Interfaces.Race.SnowFaerie, Interfaces.Civilization.Nature)
        {
            AddAbilities(new TapAbility(new OneShotEffects.SearchCreatureEffect()));
        }
    }
}
