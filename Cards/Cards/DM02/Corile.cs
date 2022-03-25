using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class Corile : Creature
    {
        public Corile() : base("Corile", 5, 2000, Subtype.CyberLord, Civilization.Water)
        {
            // When you put this creature into the battle zone, choose one of your opponent's creatures in the battle zone and put it on top of his deck.
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new CorileEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)));
        }
    }

    class CorileEffect : CardMovingChoiceEffect
    {
        public CorileEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public CorileEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Deck)
        {
        }

        public override OneShotEffect Copy()
        {
            return new CorileEffect(this);
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "Put" : "Your opponent puts")} {GetAmountAsText()} of {Filter} on top of its owner's deck.";
        }
    }
}
