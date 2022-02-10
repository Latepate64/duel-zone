using Common;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility : StaticAbility
    {
        public WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility()
        {
            ContinuousEffects.Add(new AquaKnightAbilityEffect(new CardMovedEvent { Source = ZoneType.BattleZone, Destination = ZoneType.Graveyard }));
        }

        protected WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility(WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility ability) : base(ability)
        {
        }
    }

    public class AquaKnightAbilityEffect : ReplacementEffect
    {
        public AquaKnightAbilityEffect(GameEvent gameEvent) : base(gameEvent)
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

        public override string ToString()
        {
            return "When this creature would be destroyed, return it to your hand instead.";
        }
    }
}
