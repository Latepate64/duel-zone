using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class TurboRushEffect : ContinuousEffect, IAbilityAddingEffect
    {
        private readonly IAbility _ability;

        public TurboRushEffect(IAbility ability) : base()
        {
            _ability = ability;
        }

        public TurboRushEffect(TurboRushEffect effect) : base(effect)
        {
            _ability = effect._ability;
        }

        public void AddAbility(IGame game)
        {
            var player = Controller;
            throw new System.NotImplementedException();
            //var events = game.CurrentTurn.Phases.SelectMany(x => x.GameEvents).OfType<ShieldsBrokenEvent>();
            //if (events.Any(e => game.BattleZone.GetCreatures(player).Any(c => e.Attacker.Id == c.Id && !IsSourceOfAbility(c, game))))
            //{
            //    GetSourceCard(game).AddGrantedAbility(_ability.Copy());
            //}
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
