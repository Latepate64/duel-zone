namespace Cards.Cards.DM02
{
    class FortressShell : Creature
    {
        public FortressShell() : base("Fortress Shell", 9, 5000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            // When you put this creature into the battle zone, choose up to 2 cards in your opponent's mana zone and put them into his graveyard.
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ManaBurnEffect(new CardFilters.OpponentsManaZoneCardFilter(), 0, 2, true)));
        }
    }
}
