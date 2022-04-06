using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class TurboRushEffect : ContinuousEffect, IAbilityAddingEffect
    {
        private readonly IAbility _ability;

        public TurboRushEffect(IAbility ability) : base(new TargetFilter())
        {
            _ability = ability;
        }

        public TurboRushEffect(TurboRushEffect effect) : base(effect)
        {
            _ability = effect._ability;
        }

        public void AddAbility(IGame game)
        {
            var player = GetSourceAbility(game).Controller;
            var events = game.CurrentTurn.Phases.SelectMany(x => x.GameEvents).OfType<Common.GameEvents.ShieldsBrokenEvent>();
            if (events.Any(x => Filter.Applies(game.GetCard(x.Attacker.Id), game, game.GetPlayer(player))))
            {
                foreach (var card in game.GetAllCards(Filter, player))
                {
                    game.AddAbility(card, _ability.Copy());
                }
            }
        }

        public override IContinuousEffect Copy()
        {
            return new TurboRushEffect(this);
        }

        public override string ToString()
        {
            return $"Turbo rush: {_ability.ToString()}";
        }
    }
}
