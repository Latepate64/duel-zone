namespace Cards.Cards.DM05
{
    class SchemingHands : Engine.Spell
    {
        public SchemingHands() : base("Scheming Hands", 5, Engine.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect());
        }
    }
}
