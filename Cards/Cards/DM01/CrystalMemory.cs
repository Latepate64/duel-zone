using Cards.CardFilters;
using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class CrystalMemory : Spell
    {
        public CrystalMemory() : base("Crystal Memory", 4, Common.Civilization.Water)
        {
            ShieldTrigger = true;
            // Search your deck. You may take a card from your deck and put it into your hand. Then shuffle your deck.
            AddSpellAbilities(new TutoringEffect(new OwnersDeckCardFilter(), false));
        }
    }
}
