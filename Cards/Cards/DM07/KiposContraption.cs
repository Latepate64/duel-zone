namespace Cards.Cards.DM07
{
    class KiposContraption : Creature
    {
        public KiposContraption() : base("Kipo's Contraption", 6, 3000, Engine.Subtype.Xenoparts, Engine.Civilization.Fire)
        {
            AddTapAbility(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(2000));
        }
    }
}
