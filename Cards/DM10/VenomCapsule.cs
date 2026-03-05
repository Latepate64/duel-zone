namespace Cards.DM10
{
    sealed class VenomCapsule : SilentSkillCreature
    {
        public VenomCapsule() : base("Venom Capsule", 2, 1000, Interfaces.Race.BrainJacker, Interfaces.Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldEffect());
        }
    }
}
