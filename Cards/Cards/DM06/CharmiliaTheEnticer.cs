using Common;

namespace Cards.Cards.DM06
{
    class CharmiliaTheEnticer : Creature
    {
        public CharmiliaTheEnticer() : base("Charmilia, the Enticer", 4, 3000, Subtype.SnowFaerie, Civilization.Nature)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.TutoringEffect(new CardFilters.OwnersDeckCardFilter { CardType = CardType.Creature }, true)));
        }
    }
}
