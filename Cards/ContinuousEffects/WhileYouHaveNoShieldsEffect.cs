using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileYouHaveNoShieldsEffect : ContinuousEffect, IAbilityAddingEffect
    {
        private readonly IAbility[] _abilities;

        public WhileYouHaveNoShieldsEffect(params IAbility[] abilities) : base()
        {
            _abilities = abilities;
        }

        public void AddAbility(IGame game)
        {
            if (!Source.GetController(game).ShieldZone.HasCards)
            {
                _abilities.ToList().ForEach(x => game.AddAbility(GetSourceCard(game), x.Copy()));
            }
        }

        public override IContinuousEffect Copy()
        {
            return new WhileYouHaveNoShieldsEffect();
        }

        public override string ToString()
        {
            return $"While you have no shields, this creature has {string.Join(" and ", _abilities.Select(x => $"\"{x.ToString()}\""))}.";
        }
    }
}