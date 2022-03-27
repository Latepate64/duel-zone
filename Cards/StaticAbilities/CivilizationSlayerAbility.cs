using Common;

namespace Cards.StaticAbilities
{
    class CivilizationSlayerAbility : Engine.Abilities.StaticAbility
    {
        public CivilizationSlayerAbility(params Civilization[] civilizations) : base(new ContinuousEffects.CivilizationSlayerEffect(civilizations))
        {
        }
    }
}