using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class CivilizationSlayerEffect : ContinuousEffect, ISlayerEffect, IMultiCivilizationable
    {
        public CivilizationSlayerEffect(params Civilization[] civilizations) : base()
        {
            Civilizations = civilizations;
        }

        public CivilizationSlayerEffect(CivilizationSlayerEffect effect) : base(effect)
        {
            Civilizations = effect.Civilizations;
        }

        public Civilization[] Civilizations { get; }

        public bool Applies(ICard creature, ICard against, IGame game)
        {
            return IsSourceOfAbility(creature) && against.Civilizations.Intersect(Civilizations).Any();
        }

        public override ContinuousEffect Copy()
        {
            return new CivilizationSlayerEffect(this);
        }

        public override string ToString()
        {
            return $"{string.Join(" and ", Civilizations.Select(x => x.ToString().ToLower()))} slayer";
        }
    }
}
