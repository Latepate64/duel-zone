namespace Cards.Cards.DM10
{
    public class SoderlightTheColdBlade : SilentSkillCreature
    {
        public SoderlightTheColdBlade() : base("Soderlight, the Cold Blade", 4, 4000, Engine.Race.SpiritQuartz, Engine.Civilization.Water, Engine.Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.OpponentSacrificeEffect());
        }
    }
}
