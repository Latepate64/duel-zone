using Common;

namespace Cards.Conditions
{
    class HaveAtLeastOneSubtypeCreatureInTheBattleZoneCondition : FilterAnyCondition
    {
        internal HaveAtLeastOneSubtypeCreatureInTheBattleZoneCondition(Subtype subtype) : base(new CardFilters.OwnersBattleZoneSubtypeCreatureFilter(subtype))
        {
        }
    }
}
