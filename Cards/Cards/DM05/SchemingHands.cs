namespace Cards.Cards.DM05
{
    class SchemingHands : Spell
    {
        public SchemingHands() : base("Scheming Hands", 5, Engine.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect());
        }
    }
}
