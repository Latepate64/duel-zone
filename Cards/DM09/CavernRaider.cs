using TriggeredAbilities;

namespace Cards.DM09
{
    class CavernRaider : Engine.Creature
    {
        public CavernRaider() : base("Cavern Raider", 3, 2000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new OneShotEffects.SearchCreatureEffect()));
        }
    }
}
