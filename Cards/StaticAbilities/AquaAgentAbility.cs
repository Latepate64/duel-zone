using Cards.CardFilters;
using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.Choices;
using Engine.ContinuousEffects;
using Engine.Durations;
using System;

namespace Cards.StaticAbilities
{
    public class AquaAgentAbility : StaticAbility
    {
        public AquaAgentAbility()
        {
            ContinuousEffects.Add(new AquaAgentAbilityEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent(Guid.Empty, Guid.Empty, Common.ZoneType.BattleZone, Common.ZoneType.Graveyard)));
        }

        protected AquaAgentAbility(AquaAgentAbility ability) : base(ability)
        {
        }
    }

    public class AquaAgentAbilityEffect : ReplacementEffect
    {
        public AquaAgentAbilityEffect(CardFilter filter, Duration duration, GameEvent gameEvent) : base(filter, duration, gameEvent)
        {
        }

        public AquaAgentAbilityEffect(AquaAgentAbilityEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new AquaAgentAbilityEffect(this);
        }

        public override GameEvent Apply(Game game, Engine.Player player)
        {
            if (player.Choose(new YesNoChoice(player.Id)).Decision)
            {
                var newEvent = EventToReplace.Copy() as CardMovedEvent;
                newEvent.Destination = ZoneType.Hand;
                return newEvent;
            }
            else
            {
                return null;
            }
        }

        public override bool Replaceable(GameEvent gameEvent, Game game)
        {
            if (gameEvent is CardMovedEvent e)
            {
                return e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player));
            }
            return false;
        }
    }
}
