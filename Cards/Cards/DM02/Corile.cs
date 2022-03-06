using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM02
{
    class Corile : Creature
    {
        public Corile() : base("Corile", 5, Civilization.Water, 2000, Subtype.CyberLord)
        {
            // When you put this creature into the battle zone, choose one of your opponent's creatures in the battle zone and put it on top of his deck.
            Abilities.Add(new PutIntoPlayAbility(new CorileEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)));
        }
    }
}
