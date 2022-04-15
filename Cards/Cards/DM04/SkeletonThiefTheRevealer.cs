namespace Cards.Cards.DM04
{
    class SkeletonThiefTheRevealer : Creature
    {
        public SkeletonThiefTheRevealer() : base("Skeleton Thief, the Revealer", 4, 2000, Engine.Subtype.LivingDead, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(Engine.Subtype.LivingDead));
        }
    }
}
