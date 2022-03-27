using Common;
using Engine;

namespace Cards.StaticAbilities
{
    class ThisCreatureCannotBeBlockedByCivilizationCreaturesAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCannotBeBlockedByCivilizationCreaturesAbility(Civilization civilization) : base(new ContinuousEffects.ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(civilization))
        {
        }
    }
}
