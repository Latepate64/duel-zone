using Common;

namespace Cards.Cards.DM06
{
    class GraveWormQ : Creature
    {
        public GraveWormQ() : base("Grave Worm Q", 5, 3000, Subtype.Survivor, Subtype.ParasiteWorm, Civilization.Darkness)
        {
            AddSurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSubtypeCreatureFromYourGraveyardToYourHandEffect(Subtype.Survivor)));
        }
    }
}
