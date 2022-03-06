namespace Cards.Cards.DM03
{
    class BaragaBladeOfGloom : Creature
    {
        public BaragaBladeOfGloom() : base("Baraga, Blade of Gloom", 4, 4000, Common.Subtype.DarkLord, Common.Civilization.Darkness)
        {
            // When you put this creature into the battle zone, choose one of your shields and put it into your hand. You can't use the "shield trigger" ability of that shield.
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ShieldRecoveryEffect(false)));
        }
    }
}
