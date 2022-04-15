using Common;

namespace Cards.Cards.DM07
{
    class PropellerMutant : Creature
    {
        public PropellerMutant() : base("Propeller Mutant", 2, 1000, Engine.Subtype.Hedrian, Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.OpponentRandomDiscardEffect());
        }
    }
}
