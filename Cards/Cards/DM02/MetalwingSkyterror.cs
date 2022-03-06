namespace Cards.Cards.DM02
{
    class MetalwingSkyterror : Creature
    {
        public MetalwingSkyterror() : base("Metalwing Skyterror", 7, 6000, Common.Subtype.ArmoredWyvern, Common.Civilization.Fire)
        {
            // Whenever this creature attacks, you may destroy one of your opponent's creatures that has "blocker."
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.DestroyEffect(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 0, 1, true)), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
