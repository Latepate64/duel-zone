using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM04
{
    sealed class SkeletonThiefTheRevealer : Creature
    {
        public SkeletonThiefTheRevealer() : base("Skeleton Thief, the Revealer", 4, 2000, Interfaces.Race.LivingDead, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(Interfaces.Race.LivingDead)));
        }
    }
}
