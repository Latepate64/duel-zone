using Common;

namespace Cards.Cards.DM07
{
    class Cetibols : Creature
    {
        public Cetibols() : base("Cetibols", 3, 2000, Subtype.SeaHacker, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new OneShotEffects.ControllerMayDrawCardsEffect(1)));
        }
    }
}
