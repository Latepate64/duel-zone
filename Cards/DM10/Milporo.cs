namespace Cards.DM10
{
    class Milporo : SilentSkillCreature
    {
        public Milporo() : base("Milporo", 4, 3000, Interfaces.Race.CyberLord, Interfaces.Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.DrawCardEffect());
        }
    }
}
