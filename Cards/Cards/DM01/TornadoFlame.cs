namespace Cards.Cards.DM01
{
    class TornadoFlame : Spell
    {
        public TornadoFlame() : base("Tornado Flame", 5, Common.Civilization.Fire)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(4000));
        }
    }
}
