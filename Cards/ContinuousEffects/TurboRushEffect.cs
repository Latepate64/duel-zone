using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class TurboRushEffect : AbilityAddingEffect
    {
        public TurboRushEffect(IAbility ability) : base(new Engine.TargetFilter(), new Durations.Indefinite(), new TurboRushCondition(), ability)
        {
        }

        public TurboRushEffect(TurboRushEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TurboRushEffect(this);
        }

        public override string ToString()
        {
            return $"Turbo rush: {AbilitiesAsText}";
        }
    }

    class TurboRushCondition : Condition
    {
        public TurboRushCondition() : base(new CardFilters.OwnersOtherBattleZoneCreatureFilter())
        {
        }

        public override bool Applies(IGame game, Guid player)
        {
            var events = game.CurrentTurn.Phases.SelectMany(x => x.GameEvents).OfType<Common.GameEvents.ShieldsBrokenEvent>();
            return events.Any(x => Filter.Applies(game.GetCard(x.Attacker.Id), game, game.GetPlayer(player)));
        }

        public override Condition Copy()
        {
            return new TurboRushCondition();
        }

        public override string ToString()
        {
            return "Any of your other creatures broke any shields this turn";
        }
    }
}
