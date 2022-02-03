using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    public class Corile : Creature
    {
        public Corile() : base("Corile", 5, Common.Civilization.Water, 2000, Common.Subtype.CyberLord)
        {
            // When you put this creature into the battle zone, choose one of your opponent's creatures in the battle zone and put it on top of his deck.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CardMovingChoiceEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true, Engine.Zones.ZoneType.BattleZone, Engine.Zones.ZoneType.Deck)));
        }
    }
}
