using Common;

namespace Cards.Cards.DM04
{
    class SkeletonThiefTheRevealer : Creature
    {
        public SkeletonThiefTheRevealer() : base("Skeleton Thief, the Revealer", 4, 2000, Subtype.LivingDead, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.SalvageEffect(new CardFilters.OwnersGraveyardSubtypeCreatureFilter(Subtype.LivingDead), 0, 1, true)));
        }
    }
}
