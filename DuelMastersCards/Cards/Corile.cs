using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class Corile : Creature
    {
        public Corile() : base("Corile", 5, Civilization.Water, 2000, Subtype.CyberLord)
        {
            // Choose one of your opponent's creatures in the battle zone and put it on top of his deck.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingEffect(DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.Deck, 1, 1, true, new OpponentsChoosableCreaturesFilter())));
        }
    }
}
