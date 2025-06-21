namespace Cards.DM10
{
    class VorgsEngine : SilentSkillCreature
    {
        public VorgsEngine() : base("Vorg's Engine", 2, 2000, Interfaces.Race.Xenoparts, Interfaces.Civilization.Fire)
        {
            AddSilentSkillAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(2000));
        }
    }
}
