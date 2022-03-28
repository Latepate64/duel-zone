using Common;

namespace Cards.StaticAbilities
{
    class ThisCreatureCanAttackUntappedCivilizationCreaturesAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCanAttackUntappedCivilizationCreaturesAbility(Civilization civilization) : base(new ContinuousEffects.ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(civilization)) { }
    }
}
