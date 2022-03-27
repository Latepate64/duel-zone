using Common;

namespace Cards.StaticAbilities
{
    class CivilizationBlockerAbility : Engine.Abilities.StaticAbility
    {
        public CivilizationBlockerAbility(params Civilization[] civilizations) : base(new ContinuousEffects.CivilizationBlockerEffect(civilizations))
        {
        }
    }
}