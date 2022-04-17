namespace Cards.Cards.DM08
{
    class CraniumClamp : Spell
    {
        public CraniumClamp() : base("Cranium Clamp", 4, Engine.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.YourOpponentChoosesAndDiscardsCardsFromHisHandEffect(2));
        }
    }
}