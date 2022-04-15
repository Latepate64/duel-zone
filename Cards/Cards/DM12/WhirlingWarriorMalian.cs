using Common;

namespace Cards.Cards.DM12
{
    class WhirlingWarriorMalian : Creature
    {
        public WhirlingWarriorMalian() : base("Whirling Warrior Malian", 4, 6000, Engine.Subtype.Armorloid, Civilization.Fire)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.TapThisCreatureEffect()));
        }
    }
}
