using Engine;

namespace Cards.CardFilters
{
    class DragonInYourManaZoneFilter : OwnersManaZoneCreatureFilter
    {
        public override bool Applies(ICard card, IGame game, IPlayer player)
        {
            return base.Applies(card, game, player) && card.IsDragon;
        }

        public override CardFilter Copy()
        {
            return new DragonInYourManaZoneFilter();
        }

        public override string ToString()
        {
            return "a creature that has Dragon in its race from your mana zone";
        }
    }
}
