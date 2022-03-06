namespace Cards.Cards.DM02
{
    class DarkTitanMaginn : Creature
    {
        public DarkTitanMaginn() : base("Dark Titan Maginn", 6, 4000, Common.Subtype.DemonCommand, Common.Civilization.Darkness)
        {
            // Whenever this creature attacks, your opponent discards a card at random from his hand.
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.OpponentRandomDiscardEffect()));
        }
    }
}
