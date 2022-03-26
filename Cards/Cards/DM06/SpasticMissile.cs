namespace Cards.Cards.DM06
{
    class SpasticMissile : Spell
    {
        public SpasticMissile() : base("Spastic Missile", 3, Common.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(3000));
        }
    }
}
