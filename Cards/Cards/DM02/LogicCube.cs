using Cards.CardFilters;

namespace Cards.Cards.DM02
{
    class LogicCube : Spell
    {
        public LogicCube() : base("Logic Cube", 3, Common.Civilization.Light)
        {
            ShieldTrigger = true;

            // Search your deck. You may take a spell from your deck, show that spell to your opponent, and put it into your hand. Then shuffle your deck.
            AddSpellAbilities(new OneShotEffects.TutoringEffect(new OwnersDeckSpellFilter(), true));
        }
    }
}
