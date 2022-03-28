using Common;

namespace Cards.Cards.DM04
{
    class SkeletonThiefTheRevealer : Creature
    {
        public SkeletonThiefTheRevealer() : base("Skeleton Thief, the Revealer", 4, 2000, Subtype.LivingDead, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(Subtype.LivingDead));
        }
    }
}
