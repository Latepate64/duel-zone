using Common;
using Engine;
using System.Linq;

namespace Cards.CardFilters
{
    class DragonFilter : CardFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return card.Subtypes.Intersect(new Subtype[] { Subtype.ArmoredDragon, Subtype.EarthDragon, Subtype.VolcanoDragon, Subtype.ZombieDragon }).Any();
        }

        public override ICardFilter Copy()
        {
            return new DragonFilter();
        }

        public override string ToString()
        {
            return "has dragon in its race";
        }
    }
}
