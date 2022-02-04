using Cards.CardFilters;
using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System;

namespace Cards.StaticAbilities
{
    public class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility()
        {
            ContinuousEffects.Add(new AquaKnightAbilityEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent { Source = ZoneType.BattleZone, Destination = ZoneType.Graveyard }));
        }

        protected WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility(WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility ability) : base(ability)
        {
        }
    }

    public class AquaKnightAbilityEffect : ReplacementEffect
    {
        public AquaKnightAbilityEffect(CardFilter filter, Duration duration, GameEvent gameEvent) : base(filter, duration, gameEvent)
        {
        }

        public AquaKnightAbilityEffect(AquaKnightAbilityEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new AquaKnightAbilityEffect(this);
        }

        public override GameEvent Apply(Game game, Engine.Player player)
        {
            var newEvent = EventToReplace.Copy() as CardMovedEvent;
            newEvent.Destination = ZoneType.Hand;
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
    }
}
