namespace Cards.Cards.DM10
{
    public class ChargeWhipper : SilentSkillCreature
    {
        public ChargeWhipper() : base("Charge Whipper", 3, 2000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.EmeralEffect());
        }
    }
}
