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
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CorileEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)));
        }
    }

    class CorileEffect : CardMovingChoiceEffect
    {
        public CorileEffect(CorileEffect effect) : base(effect)
        {
        }

        public CorileEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Deck)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CorileEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and put it on top of his deck.";
        }
    }
}
