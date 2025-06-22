namespace Cards.DM10
{
    sealed class ChargeWhipper : SilentSkillCreature
    {
        public ChargeWhipper() : base("Charge Whipper", 3, 2000, Interfaces.Race.CyberVirus, Interfaces.Civilization.Water)
        {
            AddSilentSkillAbility(new OneShotEffects.EmeralEffect());
        }
    }
}
