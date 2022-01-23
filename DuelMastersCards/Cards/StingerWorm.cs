using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    class StingerWorm : Creature
    {
        public StingerWorm() : base("Stinger Worm", 3, Civilization.Darkness, 5000, Subtype.ParasiteWorm)
        {
            // When you put this creature into the battle zone, destroy 1 of your creatures.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingChoiceEffect(DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Graveyard, new OwnersBattleZoneCreatureFilter(), 1, 1, true)));
        }
    }
}
