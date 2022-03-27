using Common;

namespace Cards.Cards.DM06
{
    class RippleLotusQ : Creature
    {
        public RippleLotusQ() : base("Ripple Lotus Q", 6, 2000, Civilization.Water)
        {
            AddSubtypes(Subtype.Survivor, Subtype.CyberVirus);
            AddAbilities(new StaticAbilities.SurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect())));
        }
    }
}
