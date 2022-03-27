using Common;

namespace Cards.Cards.DM05
{
    class SchemingHands : Spell
    {
        public SchemingHands() : base("Scheming Hands", 5, Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.LookAtYourOpponentsHandAndChooseCardFromItYourOpponentDiscardsThatCardEffect());
        }
    }
}
