namespace Cards.Cards.DM01
{
    class UrthPurifyingElemental : Creature
    {
        public UrthPurifyingElemental() : base("Urth, Purifying Elemental", 6, 6000, Engine.Subtype.AngelCommand, Engine.Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddAtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect());
        }
    }
}
