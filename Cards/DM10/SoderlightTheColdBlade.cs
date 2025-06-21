namespace Cards.DM10
{
    class SoderlightTheColdBlade : SilentSkillCreature
    {
        public SoderlightTheColdBlade() : base("Soderlight, the Cold Blade", 4, 4000, Interfaces.Race.SpiritQuartz, Interfaces.Civilization.Water, Interfaces.Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.OpponentSacrificeEffect());
        }
    }
}
