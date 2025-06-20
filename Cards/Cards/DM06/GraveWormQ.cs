using Abilities.Triggered;
using ContinuousEffects;
using OneShotEffects;

namespace Cards.Cards.DM06
{
    class GraveWormQ : Engine.Creature
    {
        public GraveWormQ() : base("Grave Worm Q", 5, 3000, [Engine.Race.Survivor, Engine.Race.ParasiteWorm], Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new SurvivorEffect(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new YouMayReturnRaceCreatureFromYourGraveyardToYourHandEffect(Engine.Race.Survivor))));
        }
    }
}
