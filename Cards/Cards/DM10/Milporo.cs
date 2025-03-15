namespace Cards.Cards.DM10
{
    public class Milporo : SilentSkillCreature
    {
        public Milporo() : base("Milporo", 4, 3000, Engine.Race.CyberLord, Engine.Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.DrawCardEffect());
        }
    }
}
