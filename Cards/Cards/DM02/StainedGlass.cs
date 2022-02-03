namespace Cards.Cards.DM02
{
    class StainedGlass : Creature
    {
        public StainedGlass() : base("Stained Glass", 3, Common.Civilization.Water, 1000, Common.Subtype.CyberVirus)
        {
            // Whenever this creature attacks, you may choose one of your opponent's fire or nature creatures in the battle zone and return it to its owner's hand.
            var filter = new CardFilters.OpponentsBattleZoneChoosableCreatureFilter();
            filter.Civilizations.Add(Common.Civilization.Fire);
            filter.Civilizations.Add(Common.Civilization.Nature);
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.BounceEffect(0, 1, filter)));
        }
    }
}
