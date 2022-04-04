using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class CivilizationBlockerEffect : ContinuousEffect, IBlockerEffect
    {
        private readonly Civilization[] _civilizations;

        public CivilizationBlockerEffect(params Civilization[] civilizations) : base(new TargetFilter(), new Durations.Indefinite())
        {
            _civilizations = civilizations;
        }

        public CivilizationBlockerEffect(CivilizationBlockerEffect effect) : base(effect)
        {
            _civilizations = effect._civilizations;
        }

        public bool Applies(Engine.ICard attacker, IGame game)
        {
            return attacker.Civilizations.Intersect(_civilizations).Any();
        }

        public override ContinuousEffect Copy()
        {
            return new CivilizationBlockerEffect(this);
        }

        public override string ToString()
        {
            return $"{string.Join(" and ", _civilizations.Select(x => x.ToString().ToLower()))} blocker";
        }
    }
}
