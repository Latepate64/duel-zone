using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    class StormShell : Creature
    {
        public StormShell() : base("Storm Shell", 7, Civilization.Nature, 2000, Subtype.ColonyBeetle)
        {
            // When you put this creature into the battle zone, your opponent chooses 1 of his creatures in the battle zone and puts it into his mana zone.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingChoiceEffect(new OpponentsBattleZoneCreatureFilter(), 1, 1, false, ZoneType.BattleZone, ZoneType.ManaZone)));
        }
    }
}
