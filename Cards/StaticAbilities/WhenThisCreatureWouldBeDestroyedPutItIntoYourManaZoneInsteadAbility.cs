using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility()
        {
            ContinuousEffects.Add(new MightyShouterAbilityEffect(new CardMovedEvent { Source = ZoneType.BattleZone, Destination = ZoneType.Graveyard }));
        }

        protected WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility(WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility ability) : base(ability)
        {
        }
    }

    public class MightyShouterAbilityEffect : ReplacementEffect
    {
        public MightyShouterAbilityEffect(GameEvent gameEvent) : base(gameEvent)
        {
        }

        public MightyShouterAbilityEffect(MightyShouterAbilityEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new MightyShouterAbilityEffect(this);
        }

        public override GameEvent Apply(Game game, Engine.Player player)
        {
            var newEvent = EventToReplace.Copy() as CardMovedEvent;
            newEvent.Destination = ZoneType.ManaZone;
            return newEvent;
        }

        public override bool Replaceable(GameEvent gameEvent, Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player.Id));
            }
            return false;
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, put it into your mana zone instead.";
        }
    }
}
