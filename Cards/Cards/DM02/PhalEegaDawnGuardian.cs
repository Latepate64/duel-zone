namespace Cards.Cards.DM02
{
    class PhalEegaDawnGuardian : Creature
    {
        public PhalEegaDawnGuardian() : base("Phal Eega, Dawn Guardian", 5, 4000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            // When you put this creature into the battle zone, you may return a spell from your graveyard to your hand.
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.SalvageEffect(new CardFilters.OwnersGraveyardCardFilter { CardType = Common.CardType.Spell }, 0, 1, true)));
        }
    }
}
