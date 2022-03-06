using Cards.CardFilters;

namespace Cards.Cards.DM02
{
    class RumblingTerahorn : Creature
    {
        public RumblingTerahorn() : base("Rumbling Terahorn", 5, 3000, Common.Subtype.HornedBeast, Common.Civilization.Nature)
        {
            // When you put this creature into the battle zone, search your deck. You may take a creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.SearchDeckEffect(new OwnersDeckCardFilter { CardType = Common.CardType.Creature }, true)));
        }
    }
}
