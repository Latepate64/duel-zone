namespace Cards.Cards.DM02
{
    class SilverAxe : Creature
    {
        public SilverAxe() : base("Silver Axe", 3, 1000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            // Whenever this creature attacks, you may put the top card of your deck into your mana zone.
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.MayPutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
