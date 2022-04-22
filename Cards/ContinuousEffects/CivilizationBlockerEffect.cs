using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class CivilizationBlockerEffect : ContinuousEffect, IBlockerEffect, IMultiCivilizationable
    {
        public CivilizationBlockerEffect(params Civilization[] civilizations) : base()
        {
            Civilizations = civilizations;
        }

        public CivilizationBlockerEffect(CivilizationBlockerEffect effect) : base(effect)
        {
            Civilizations = effect.Civilizations;
        }

        public Civilization[] Civilizations { get; }

        public bool CanBlock(ICard blocker, ICard attacker, IGame game)
        {
            return IsSourceOfAbility(blocker) && attacker.Civilizations.Intersect(Civilizations).Any();
        }

        public override ContinuousEffect Copy()
        {
            return new CivilizationBlockerEffect(this);
        }

        public override string ToString()
        {
            return $"{string.Join(" and ", Civilizations.Select(x => x.ToString().ToLower()))} blocker";
        }
    }
}
