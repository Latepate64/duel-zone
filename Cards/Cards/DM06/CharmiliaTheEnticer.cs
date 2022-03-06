using Common;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class CharmiliaTheEnticer : Creature
    {
        public CharmiliaTheEnticer() : base("Charmilia, the Enticer", 4, 3000, Subtype.SnowFaerie, Civilization.Nature)
        {
            AddAbilities(new TapAbility(new OneShotEffects.SearchDeckEffect(new CardFilters.OwnersDeckCardFilter { CardType = CardType.Creature }, true)));
        }
    }
}
