namespace Cards.Cards.DM03
{
    class RaVuSeekerOfLightning : Creature
    {
        public RaVuSeekerOfLightning() : base("Ra Vu, Seeker of Lightning", 6, 4000, Common.Subtype.MechaThunder, Common.Civilization.Light)
        {
            // Whenever this creature attacks, you may return a light spell from your graveyard to your hand.
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.SalvageEffect(new CardFilters.OwnersGraveyardCivilizationSpellFilter(Common.Civilization.Light), 0, 1, true)));
        }
    }
}
