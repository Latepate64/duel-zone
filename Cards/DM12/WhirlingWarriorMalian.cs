using TriggeredAbilities;

namespace Cards.DM12
{
    class WhirlingWarriorMalian : Engine.Creature
    {
        public WhirlingWarriorMalian() : base("Whirling Warrior Malian", 4, 6000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.TapThisCreatureEffect()));
        }
    }
}
