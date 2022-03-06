namespace Cards.Cards.DM03
{
    class GamilKnightOfHatred : Creature
    {
        public GamilKnightOfHatred() : base("Gamil, Knight of Hatred", 6, Common.Civilization.Darkness, 4000, Common.Subtype.DemonCommand)
        {
            // Whenever this creature attacks, you may return a darkness creature from your graveyard to your hand.
            Abilities.Add(new TriggeredAbilities.AttackAbility(new OneShotEffects.SalvageEffect(new CardFilters.OwnersGraveyardCardFilter(Common.Civilization.Darkness) { CardType = Common.CardType.Creature }, 0, 1, true)));
        }
    }
}
