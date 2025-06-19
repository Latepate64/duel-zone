using Cards.TriggeredAbilities;

namespace Cards.Cards.DM07
{
    class Cetibols : Creature
    {
        public Cetibols() : base("Cetibols", 3, 2000, Engine.Race.SeaHacker, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDrawCardEffect()));
        }
    }
}
