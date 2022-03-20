namespace Cards.Cards.DM03
{
    class FloodValve : Spell
    {
        public FloodValve() : base("Flood Valve", 2, Common.Civilization.Water)
        {
            ShieldTrigger = true;

            // Return a card from your mana zone to your hand.
            AddSpellAbilities(new OneShotEffects.SelfManaRecoveryEffect(1, 1, true, new CardFilters.OwnersManaZoneCardFilter()));
        }
    }
}
