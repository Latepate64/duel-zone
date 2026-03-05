namespace Cards.DM01
{
    sealed class TornadoFlame : Spell
    {
        public TornadoFlame() : base("Tornado Flame", 5, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(4000));
        }
    }
}
