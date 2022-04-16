namespace Cards.Cards.DM07
{
    class Cetibols : Creature
    {
        public Cetibols() : base("Cetibols", 3, 2000, Engine.Race.SeaHacker, Engine.Civilization.Water)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDrawCardsEffect(1));
        }
    }
}
