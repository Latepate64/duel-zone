using TriggeredAbilities;

namespace Cards.DM08
{
    class SlaphappySoldierGalback : TurboRushCreature
    {
        public SlaphappySoldierGalback() : base("Slaphappy Soldier Galback", 4, 3000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddTurboRushAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(4000)));
        }
    }
}
