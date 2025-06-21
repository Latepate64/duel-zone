using TriggeredAbilities;

namespace Cards.DM08
{
    class SlaphappySoldierGalback : TurboRushCreature
    {
        public SlaphappySoldierGalback() : base("Slaphappy Soldier Galback", 4, 3000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddTurboRushAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesThatHasMaxPowerEffect(4000)));
        }
    }
}
