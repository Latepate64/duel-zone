using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class CivilizationSlayerEffect : ContinuousEffect, ISlayerEffect
    {
        private readonly Civilization[] _civilizations;

        public CivilizationSlayerEffect(params Civilization[] civilizations) : base()
        {
            _civilizations = civilizations;
        }

        public CivilizationSlayerEffect(CivilizationSlayerEffect effect) : base(effect)
        {
            _civilizations = effect._civilizations;
        }

        public bool Applies(ICard creature, ICard against, IGame game)
        {
            return IsSourceOfAbility(creature, game) && against.Civilizations.Intersect(_civilizations).Any();
        }

        public override ContinuousEffect Copy()
        {
            return new CivilizationSlayerEffect(this);
        }

        public override string ToString()
        {
            return $"{string.Join(" and ", _civilizations.Select(x => x.ToString().ToLower()))} slayer";
        }
    }
}
