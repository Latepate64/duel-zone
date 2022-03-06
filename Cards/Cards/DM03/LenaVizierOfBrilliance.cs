namespace Cards.Cards.DM03
{
    class LenaVizierOfBrilliance : Creature
    {
        public LenaVizierOfBrilliance() : base("Lena, Vizier of Brilliance", 4, 2000, Common.Subtype.Initiate, Common.Civilization.Light)
        {
            // When you put this creature into the battle zone, you may return a spell from your mana zone to your hand.
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCardFilter { CardType = Common.CardType.Spell }, 0, 1, true)));
        }
    }
}
