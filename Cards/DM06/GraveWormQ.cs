using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;

namespace Cards.DM06
{
    sealed class GraveWormQ : Engine.Creature
    {
        public GraveWormQ() : base("Grave Worm Q", 5, 3000, [Interfaces.Race.Survivor, Interfaces.Race.ParasiteWorm], Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new SurvivorEffect(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(Interfaces.Race.Survivor))));
        }
    }
}
