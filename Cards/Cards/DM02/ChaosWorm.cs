using Abilities.Triggered;

namespace Cards.Cards.DM02
{
    class ChaosWorm : EvolutionCreature
    {
        public ChaosWorm() : base("Chaos Worm", 5, 5000, Engine.Race.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesEffect()));
        }
    }
}
