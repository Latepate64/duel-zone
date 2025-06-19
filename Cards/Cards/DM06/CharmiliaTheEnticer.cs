using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class CharmiliaTheEnticer : Engine.Creature
    {
        public CharmiliaTheEnticer() : base("Charmilia, the Enticer", 4, 3000, Engine.Race.SnowFaerie, Engine.Civilization.Nature)
        {
            AddAbilities(new TapAbility(new OneShotEffects.SearchCreatureEffect()));
        }
    }
}
