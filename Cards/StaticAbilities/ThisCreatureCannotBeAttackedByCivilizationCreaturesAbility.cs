using Common;

namespace Cards.StaticAbilities
{
    class ThisCreatureCannotBeAttackedByCivilizationCreaturesAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCannotBeAttackedByCivilizationCreaturesAbility(params Civilization[] civilizations) : base(new ContinuousEffects.ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(civilizations))
        {
        }
    }
}