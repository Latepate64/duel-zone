using DuelMastersModels;

namespace DuelMastersCards.Cards.DM03
{
    class GamilKnightOfHatred : Creature
    {
        public GamilKnightOfHatred() : base("Gamil, Knight of Hatred", 6, Civilization.Darkness, 4000, Subtype.DemonCommand)
        {
            // Whenever this creature attacks, you may return a darkness creature from your graveyard to your hand.
            var filter = new CardFilters.OwnersGraveyardCardFilter { CardType = CardType.Creature };
            filter.Civilizations.Add(Civilization.Darkness);
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SalvageEffect(filter, 0, 1, true)));
        }
    }
}
