using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards.DM02
{
    class LogicCube : Spell
    {
        public LogicCube() : base("Logic Cube", 3, Civilization.Light)
        {
            ShieldTrigger = true;

            // Search your deck. You may take a spell from your deck, show that spell to your opponent, and put it into your hand. Then shuffle your deck.
            Abilities.Add(new SpellAbility(new OneShotEffects.SearchDeckEffect(new CardFilters.OwnersDeckSpellFilter(), true)));
        }
    }
}
