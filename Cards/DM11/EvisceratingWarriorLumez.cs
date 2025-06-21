using TriggeredAbilities;

namespace Cards.DM11
{
    class EvisceratingWarriorLumez : WaveStrikerCreature
    {
        public EvisceratingWarriorLumez() : base("Eviscerating Warrior Lumez", 3, 2000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(2000)));
        }
    }
}
