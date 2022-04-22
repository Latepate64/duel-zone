namespace Cards.Cards.DM07
{
    class PropellerMutant : Creature
    {
        public PropellerMutant() : base("Propeller Mutant", 2, 1000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.OpponentDiscardsCardAtRandomEffect());
        }
    }
}
