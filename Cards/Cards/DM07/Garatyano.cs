using Cards.OneShotEffects;
using Engine;

namespace Cards.Cards.DM07
{
    class Garatyano : Creature
    {
        public Garatyano() : base("Garatyano", 4, 2000, Race.SeaHacker, Civilization.Water)
        {
            AddTapAbility(new LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect(3));
        }
    }
}
