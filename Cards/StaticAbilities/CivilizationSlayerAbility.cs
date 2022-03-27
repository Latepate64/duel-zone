using Common;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.StaticAbilities
{
    class CivilizationSlayerAbility : Engine.Abilities.StaticAbility
    {
        public CivilizationSlayerAbility(params Civilization[] civilizations) : base(new CivilizationSlayerEffect(civilizations))
        {
        }
    }

    class CivilizationSlayerEffect : SlayerEffect
    {
        private readonly Civilization[] _civilizations;

        public CivilizationSlayerEffect(params Civilization[] civilizations) : base(new Engine.TargetFilter(), new CardFilters.BattleZoneCivilizationCreatureFilter(civilizations), new Durations.Indefinite())
        {
            _civilizations = civilizations;
        }

        public CivilizationSlayerEffect(CivilizationSlayerEffect effect) : base(effect)
        {
            _civilizations = effect._civilizations;
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