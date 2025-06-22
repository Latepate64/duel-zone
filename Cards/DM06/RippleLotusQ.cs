using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    sealed class RippleLotusQ : Engine.Creature
    {
        public RippleLotusQ() : base("Ripple Lotus Q", 6, 2000, [Interfaces.Race.Survivor, Interfaces.Race.CyberVirus], Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new SurvivorEffect(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect())));
        }
    }
}
