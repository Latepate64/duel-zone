namespace Cards.DM05
{
    class SchemingHands : Engine.Spell
    {
        public SchemingHands() : base("Scheming Hands", 5, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect());
        }
    }
}
