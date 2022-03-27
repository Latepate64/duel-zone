using Common;

namespace Cards.StaticAbilities
{
    class ThisCreatureCannotBeAttackedByCivilizationCreaturesAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCannotBeAttackedByCivilizationCreaturesAbility(params Civilization[] civilizations) : base(new Engine.ContinuousEffects.CannotBeAttackedEffect(new Engine.TargetFilter(), new CardFilters.OpponentsBattleZoneCivilizationCreatureFilter(civilizations)))
        {
        }
    }
}