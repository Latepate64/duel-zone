using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DiscardUpToCards : DiscardEffect
    {
        public DiscardUpToCards(int maximum) : base(new CardFilters.OwnersHandCardFilter(), 0, maximum, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return Maximum == 1 ? "You may discard a card." : $"You may discard up to {Maximum} cards.";
        }
    }
}