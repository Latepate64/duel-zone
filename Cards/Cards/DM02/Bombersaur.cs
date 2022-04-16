namespace Cards.Cards.DM02
{
    class Bombersaur : Creature
    {
        public Bombersaur() : base("Bombersaur", 5, 5000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.MutualManaSacrificeEffect(2));
        }
    }
}
