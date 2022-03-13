using Cards.ContinuousEffects;
using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility() : base(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(new CardMovedEvent { Source = ZoneType.BattleZone, Destination = ZoneType.Graveyard }))
        {
        }
    }

    class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : DestructionReplacementEffect
    {
        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(GameEvent gameEvent) : base(gameEvent)
        {
        }

        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect(this);
        }

        public override bool Apply(Game game, Engine.Player player)
        {
            game.Move(ZoneType.BattleZone, ZoneType.ManaZone, GetAffectedCards(game).ToArray());
            return true;
        }

        public override string ToString()
        {
            return base.ToString() + "put it into your mana zone instead.";
        }
    }
}
