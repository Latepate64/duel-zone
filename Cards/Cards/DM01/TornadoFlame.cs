namespace Cards.Cards.DM01
{
    class TornadoFlame : Spell
    {
        public TornadoFlame() : base("Tornado Flame", 5, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(4000));
        }
    }
}
