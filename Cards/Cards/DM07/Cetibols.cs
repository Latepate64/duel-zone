using Common;

namespace Cards.Cards.DM07
{
    class Cetibols : Creature
    {
        public Cetibols() : base("Cetibols", 3, 2000, Engine.Subtype.SeaHacker, Civilization.Water)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDrawCardsEffect(1));
        }
    }
}
