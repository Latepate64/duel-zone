namespace Cards.DM05
{
    sealed class SchemingHands : Spell
    {
        public SchemingHands() : base("Scheming Hands", 5, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect());
        }
    }
}
