using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.Cards.DM11
{
    class LamielDestinyEnforcer : WaveStrikerCreature
    {
        public LamielDestinyEnforcer() : base("Lamiel, Destiny Enforcer", 5, 3000, Race.Berserker, Civilization.Light)
        {
            AddWaveStrikerAbility(new LamielAbility());
        }
    }

    class LamielAbility : TriggeredAbility
    {
        public LamielAbility() : base(new OneShotEffects.YouMayDrawCardEffect())
        {
        }

        public LamielAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CardMovedEvent e && e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && e.CardInDestinationZone.Owner == Controller && e.CardInDestinationZone != Source;
        }

        public override IAbility Copy()
        {
            return new LamielAbility(this);
        }

        public override string ToString()
        {
            return "Whenever one of your creatures is destroyed during your opponent's turn, you may draw a card.";
        }
    }
}
