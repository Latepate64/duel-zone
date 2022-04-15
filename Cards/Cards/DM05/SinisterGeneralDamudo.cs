namespace Cards.Cards.DM05
{
    class SinisterGeneralDamudo : Creature
    {
        public SinisterGeneralDamudo() : base("Sinister General Damudo", 6, 5000, Engine.Subtype.DarkLord, Engine.Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(3000));
        }
    }
}
