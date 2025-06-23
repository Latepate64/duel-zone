namespace Cards.DM02
{
    sealed class LostSoul : Spell
    {
        public LostSoul() : base("Lost Soul", 7, Interfaces.Civilization.Darkness)
        {
            AddSpellAbilities(new OneShotEffects.YourOpponentDiscardsHisHandEffect());
        }
    }
}
