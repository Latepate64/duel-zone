using Abilities.Triggered;

namespace Cards.Cards.DM11
{
    class EvisceratingWarriorLumez : WaveStrikerCreature
    {
        public EvisceratingWarriorLumez() : base("Eviscerating Warrior Lumez", 3, 2000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(2000)));
        }
    }
}
