using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class Meteosaur : Creature
    {
        public Meteosaur() : base("Meteosaur", 5, 2000, Common.Subtype.RockBeast, Common.Civilization.Fire)
        {
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(2000)));
        }
    }
}
