using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.Choices;
using Engine.ContinuousEffects;
using Engine.Durations;
using Engine.GameEvents;
using System;

namespace Cards.StaticAbilities
{
    public class AquaAgentAbility : StaticAbility
    {
        public AquaAgentAbility()
        {
            ContinuousEffects.Add(new AquaAgentAbilityEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent(Guid.Empty, Guid.Empty, Engine.Zones.ZoneType.BattleZone, Engine.Zones.ZoneType.Graveyard, null)));
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

        public override GameEvent Apply(Game game, Player player)
        {
            if (player.Choose(new YesNoChoice(player.Id)).Decision)
            {
                var newEvent = EventToReplace.Copy() as CardMovedEvent;
                newEvent.Destination = Engine.Zones.ZoneType.Hand;
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
                return e.Source == Engine.Zones.ZoneType.BattleZone && e.Destination == Engine.Zones.ZoneType.Graveyard && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player));
            }
            return false;
        }
    }
}
