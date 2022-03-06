using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    class CraniumClamp : Spell
    {
        public CraniumClamp() : base("Cranium Clamp", 4, Common.Civilization.Darkness)
        {
            // Your opponent chooses and discards 2 cards from his hand.
            AddAbilities(new SpellAbility(new DiscardEffect(new OpponentsHandCardFilter(), 2, 2, false)));
        }
    }
}
