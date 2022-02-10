using Cards.CardFilters;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class LogicCube : Spell
    {
        public LogicCube() : base("Logic Cube", 3, Common.Civilization.Light)
        {
            ShieldTrigger = true;

            // Search your deck. You may take a spell from your deck, show that spell to your opponent, and put it into your hand. Then shuffle your deck.
            Abilities.Add(new SpellAbility(new OneShotEffects.SearchDeckEffect(new OwnersDeckCardFilter { CardType = Common.CardType.Spell }, true)));
        }
    }
}
