namespace Cards.Cards.DM02
{
    class GeneralDarkFiend : Creature
    {
        public GeneralDarkFiend() : base("General Dark Fiend", 5, 6000, Common.Subtype.DarkLord, Common.Civilization.Darkness)
        {
            // Whenever this creature attacks, choose one of your shields without looking and put it into your graveyard. You can't use the "shield trigger" ability of that shield.
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.SelfShieldBurnEffect()));
            AddAbilities(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
