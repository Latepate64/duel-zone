namespace Cards.Cards.DM06
{
    class CharmiliaTheEnticer : Creature
    {
        public CharmiliaTheEnticer() : base("Charmilia, the Enticer", 4, 3000, Engine.Subtype.SnowFaerie, Engine.Civilization.Nature)
        {
            AddTapAbility(new OneShotEffects.SearchCreatureEffect());
        }
    }
}
