using TriggeredAbilities;

namespace Cards.DM07
{
    class Cetibols : Engine.Creature
    {
        public Cetibols() : base("Cetibols", 3, 2000, Engine.Race.SeaHacker, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDrawCardEffect()));
        }
    }
}
