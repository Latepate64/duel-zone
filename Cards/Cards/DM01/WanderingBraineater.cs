namespace Cards.Cards.DM01
{
    class WanderingBraineater : Creature
    {
        public WanderingBraineater() : base("Wandering Braineater", 2, 2000, Engine.Race.LivingDead, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
