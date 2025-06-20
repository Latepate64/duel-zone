using Abilities.Triggered;
using OneShotEffects;

namespace Cards.Cards.DM01
{
    class Meteosaur : Engine.Creature
    {
        public Meteosaur() : base("Meteosaur", 5, 2000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(2000)));
        }
    }
}
