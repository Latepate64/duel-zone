using TriggeredAbilities;

namespace Cards.DM07
{
    class PropellerMutant : Engine.Creature
    {
        public PropellerMutant() : base("Propeller Mutant", 2, 1000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
