using Cards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace Cards.Cards.DM03
{
    class Psyshroom : Creature
    {
        public Psyshroom() : base("Psyshroom", 4, Civilization.Nature, 2000, Subtype.BalloonMushroom)
        {
            // Whenever this creature attacks, you may put a nature card from your graveyard into your mana zone.
            var filter = new CardFilters.OwnersGraveyardCardFilter();
            filter.Civilizations.Add(Civilization.Nature);
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new CardMovingChoiceEffect(filter, 0, 1, true, ZoneType.Graveyard, ZoneType.ManaZone)));
        }
    }
}
