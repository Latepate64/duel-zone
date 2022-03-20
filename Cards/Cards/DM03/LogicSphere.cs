namespace Cards.Cards.DM03
{
    class LogicSphere : Spell
    {
        public LogicSphere() : base("Logic Sphere", 3, Common.Civilization.Light)
        {
            ShieldTrigger = true;

            // Return a spell from your mana zone to your hand.
            AddSpellAbilities(new OneShotEffects.ManaSpellRecoveryEffect(true));
        }
    }
}
