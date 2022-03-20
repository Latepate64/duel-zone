using Common;

namespace Cards.StaticAbilities
{
    class ThisCreatureCannotBeAttackedByCivilizationCreaturesAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCannotBeAttackedByCivilizationCreaturesAbility(Civilization civilization) : base(new Engine.ContinuousEffects.CannotBeAttackedEffect(new Engine.TargetFilter(), new CardFilters.OpponentsBattleZoneCivilizationCreatureFilter(civilization)))
        {
        }
    }
}