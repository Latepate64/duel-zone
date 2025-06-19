using Cards.TriggeredAbilities;

namespace Cards.Cards.DM04
{
    class SkeletonThiefTheRevealer : Engine.Creature
    {
        public SkeletonThiefTheRevealer() : base("Skeleton Thief, the Revealer", 4, 2000, Engine.Race.LivingDead, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(Engine.Race.LivingDead)));
        }
    }
}
