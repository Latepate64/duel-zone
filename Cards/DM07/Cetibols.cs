using TriggeredAbilities;

namespace Cards.DM07
{
    sealed class Cetibols : Engine.Creature
    {
        public Cetibols() : base("Cetibols", 3, 2000, Interfaces.Race.SeaHacker, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDrawCardEffect()));
        }
    }
}
