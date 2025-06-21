namespace Cards.DM10
{
    class SporeblastErengi : SilentSkillCreature
    {
        public SporeblastErengi() : base("Sporeblast Erengi", 4, 4000, Interfaces.Race.BalloonMushroom, Interfaces.Civilization.Nature)
        {
            AddSilentSkillAbility(new OneShotEffects.SearchCreatureEffect());
        }
    }
}
