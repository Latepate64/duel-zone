using Cards.CardFilters;
using Common;
using Engine;

namespace Cards.StaticAbilities
{
    class ThisCreatureCanAttackUntappedCivilizationCreaturesAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCanAttackUntappedCivilizationCreaturesAbility(Civilization civilization) : base(new ContinuousEffects.ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(civilization)) { }
    }
}
