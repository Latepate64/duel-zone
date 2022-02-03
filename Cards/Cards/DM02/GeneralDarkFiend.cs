namespace Cards.Cards.DM02
{
    class GeneralDarkFiend : Creature
    {
        public GeneralDarkFiend() : base("General Dark Fiend", 5, Common.Civilization.Darkness, 6000, Common.Subtype.DarkLord)
        {
            // Whenever this creature attacks, choose one of your shields without looking and put it into your graveyard. You can't use the "shield trigger" ability of that shield.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.ShieldBurnEffect(new CardFilters.OwnersShieldZoneCardFilter(), 1, 1, true)));
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
