using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Common.Choices;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class AquaAgentAbility : StaticAbility
    {
        public AquaAgentAbility()
        {
            ContinuousEffects.Add(new AquaAgentAbilityEffect(new CardMovedEvent { Source = ZoneType.BattleZone, Destination = ZoneType.Graveyard }));
        }

        protected AquaAgentAbility(AquaAgentAbility ability) : base(ability)
        {
        }
    }

    public class AquaAgentAbilityEffect : ReplacementEffect
    {
        public AquaAgentAbilityEffect(GameEvent gameEvent) : base(gameEvent)
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
            if (player.Choose(new YesNoChoice(player.Id, ToString()), game).Decision)
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
                return e.Source == ZoneType.BattleZone && e.Destination == ZoneType.Graveyard && Filter.Applies(game.GetCard(e.CardInSourceZone), game, game.GetPlayer(e.Player.Id));
            }
            return false;
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, you may return it to your hand instead.";
        }
    }
}
