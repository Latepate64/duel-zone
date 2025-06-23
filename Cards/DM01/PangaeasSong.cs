namespace Cards.DM01
{
    sealed class PangaeasSong : Spell
    {
        public PangaeasSong() : base("Pangaea's Song", 1, Interfaces.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect());
        }
    }
}
