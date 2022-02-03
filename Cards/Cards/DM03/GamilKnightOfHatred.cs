namespace Cards.Cards.DM03
{
    class GamilKnightOfHatred : Creature
    {
        public GamilKnightOfHatred() : base("Gamil, Knight of Hatred", 6, Common.Civilization.Darkness, 4000, Common.Subtype.DemonCommand)
        {
            // Whenever this creature attacks, you may return a darkness creature from your graveyard to your hand.
            var filter = new CardFilters.OwnersGraveyardCardFilter { CardType = Common.CardType.Creature };
            filter.Civilizations.Add(Common.Civilization.Darkness);
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SalvageEffect(filter, 0, 1, true)));
        }
    }
}
