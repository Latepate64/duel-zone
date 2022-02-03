namespace Cards.Cards.DM02
{
    class DarkTitanMaginn : Creature
    {
        public DarkTitanMaginn() : base("Dark Titan Maginn", 6, Common.Civilization.Darkness, 4000, Common.Subtype.DemonCommand)
        {
            // Whenever this creature attacks, your opponent discards a card at random from his hand.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.OpponentRandomDiscardEffect()));
        }
    }
}
