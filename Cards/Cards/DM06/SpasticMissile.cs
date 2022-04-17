namespace Cards.Cards.DM06
{
    class SpasticMissile : Spell
    {
        public SpasticMissile() : base("Spastic Missile", 3, Engine.Civilization.Fire)
        {
            AddSpellAbilities(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(3000));
        }
    }
}
