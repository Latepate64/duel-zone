using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.Choices;
using Engine.ContinuousEffects;
using Engine.Durations;
using Engine.GameEvents;
using System;
using System.Linq;

namespace Cards.StaticAbilities
{
    public class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility()
        {
            ContinuousEffects.Add(new AquaKnightAbilityEffect(new TargetFilter(), new Indefinite(), new CardMovedEvent(Guid.Empty, Guid.Empty, Engine.Zones.ZoneType.BattleZone, Engine.Zones.ZoneType.Graveyard, null)));
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

        public override GameEvent Apply(Game game, Player player)
        {
            var newEvent = EventToReplace.Copy() as CardMovedEvent;
            newEvent.Destination = Engine.Zones.ZoneType.Hand;
            return newEvent;
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
