namespace Cards.Cards.DM03
{
    class GamilKnightOfHatred : Creature
    {
        public GamilKnightOfHatred() : base("Gamil, Knight of Hatred", 6, 4000, Common.Subtype.DemonCommand, Common.Civilization.Darkness)
        {
            // Whenever this creature attacks, you may return a darkness creature from your graveyard to your hand.
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SalvageCivilizationCreatureEffect(0, 1, Common.Civilization.Darkness)));
        }
    }
}
