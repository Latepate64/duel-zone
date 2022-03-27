using Common;

namespace Cards.Cards.DM02
{
    class ChaosWorm : EvolutionCreature
    {
        public ChaosWorm() : base("Chaos Worm", 5, 5000, Subtype.ParasiteWorm, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesEffect()));
        }
    }
}
