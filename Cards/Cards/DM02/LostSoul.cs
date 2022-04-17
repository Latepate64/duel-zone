namespace Cards.Cards.DM02
{
    class LostSoul : Spell
    {
        public LostSoul() : base("Lost Soul", 7, Engine.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.YourOpponentDiscardsHisHandEffect());
        }
    }
}
