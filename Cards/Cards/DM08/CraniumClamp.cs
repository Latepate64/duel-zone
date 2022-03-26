namespace Cards.Cards.DM08
{
    class CraniumClamp : Spell
    {
        public CraniumClamp() : base("Cranium Clamp", 4, Common.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(2));
        }
    }
}