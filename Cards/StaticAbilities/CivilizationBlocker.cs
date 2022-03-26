using Common;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    class CivilizationBlockerAbility : Engine.Abilities.StaticAbility
    {
        public CivilizationBlockerAbility(params Civilization[] civilizations) : base(new CivilizationBlockerEffect(civilizations))
        {
        }
    }

    class CivilizationBlockerEffect : BlockerEffect
    {
        private readonly Civilization[] _civilizations;

        public CivilizationBlockerEffect(params Civilization[] civilizations) : base(new Engine.TargetFilter(), new CardFilters.OpponentsBattleZoneCivilizationCreatureFilter(civilizations), new Durations.Indefinite())
        {
            _civilizations = civilizations;
        }

        public CivilizationBlockerEffect(CivilizationBlockerEffect effect) : base(effect)
        {
            _civilizations = effect._civilizations;
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