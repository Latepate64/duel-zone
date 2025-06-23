namespace Cards.DM06
{
    sealed class SpasticMissile : Spell
    {
        public SpasticMissile() : base("Spastic Missile", 3, Interfaces.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(3000));
        }
    }
}
