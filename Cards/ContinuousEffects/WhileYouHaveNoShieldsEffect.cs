using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class WhileYouHaveNoShieldsEffect : ContinuousEffect, IAbilityAddingEffect
    {
        private readonly IAbility[] _abilities;

        protected WhileYouHaveNoShieldsEffect(params IAbility[] abilities) : base()
        {
            _abilities = abilities;
        }

        protected WhileYouHaveNoShieldsEffect(IContinuousEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            if (!Ability.GetController(game).ShieldZone.HasCards)
            {
                _abilities.ToList().ForEach(x => game.AddAbility(Source, x.Copy()));
            }
        }

        public override string ToString()
        {
            return $"While you have no shields, this creature has {string.Join(" and ", _abilities.Select(x => $"\"{x.ToString()}\""))}.";
        }
    }
}