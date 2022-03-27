using Common;

namespace Cards.Cards.DM12
{
    class WhirlingWarriorMalian : Creature
    {
        public WhirlingWarriorMalian() : base("Whirling Warrior Malian", 4, 6000, Subtype.Armorloid, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.TapThisCreatureEffect()));
        }
    }
}
