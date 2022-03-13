using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class DimensionGate : Spell
    {
        public DimensionGate() : base("Dimension Gate", 3, Common.Civilization.Nature)
        {
            ShieldTrigger = true;

            // Search your deck. You may take a creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.
            AddAbilities(new SpellAbility(new TutoringEffect(new OwnersDeckCardFilter { CardType = Common.CardType.Creature }, true)));
        }
    }
}
