using Common;

namespace Cards.Cards.DM07
{
    class PropellerMutant : Creature
    {
        public PropellerMutant() : base("Propeller Mutant", 2, 1000, Subtype.Hedrian, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new OneShotEffects.OpponentRandomDiscardEffect()));
        }
    }
}
