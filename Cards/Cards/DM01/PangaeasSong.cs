namespace Cards.Cards.DM01
{
    class PangaeasSong : Spell
    {
        public PangaeasSong() : base("Pangaea's Song", 1, Common.Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect());
        }
    }
}
