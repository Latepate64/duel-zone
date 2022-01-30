using DuelMastersModels;

namespace Cards.Cards.DM03
{
    class RaVuSeekerOfLightning : Creature
    {
        public RaVuSeekerOfLightning() : base("Ra Vu, Seeker of Lightning", 6, Civilization.Light, 4000, Subtype.MechaThunder)
        {
            // Whenever this creature attacks, you may return a light spell from your graveyard to your hand.
            var filter = new CardFilters.OwnersGraveyardCardFilter { CardType = CardType.Spell };
            filter.Civilizations.Add(Civilization.Light);
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SalvageEffect(filter, 0, 1, true)));
        }
    }
}
