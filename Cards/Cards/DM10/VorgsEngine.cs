namespace Cards.Cards.DM10
{
    public class VorgsEngine : SilentSkillCreature
    {
        public VorgsEngine() : base("Vorg's Engine", 2, 2000, Engine.Race.Xenoparts, Engine.Civilization.Fire)
        {
            AddSilentSkillAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(2000));
        }
    }
}
