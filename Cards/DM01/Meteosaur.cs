using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    sealed class Meteosaur : Engine.Creature
    {
        public Meteosaur() : base("Meteosaur", 5, 2000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(2000)));
        }
    }
}
