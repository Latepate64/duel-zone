using TriggeredAbilities;

namespace Cards.DM12
{
    sealed class WhirlingWarriorMalian : Engine.Creature
    {
        public WhirlingWarriorMalian() : base("Whirling Warrior Malian", 4, 6000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.TapThisCreatureEffect()));
        }
    }
}
