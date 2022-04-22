using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class YouMayDrawCardsEffect : OneShotEffect
    {
        public int Maximum { get; }

        protected YouMayDrawCardsEffect(int maximum) : base()
        {
            Maximum = maximum;
        }

        protected YouMayDrawCardsEffect(YouMayDrawCardsEffect effect)
        {
            Maximum = effect.Maximum;
        }

        public override void Apply(IGame game)
        {
            Controller.DrawCardsOptionally(game, Ability, Maximum);
        }

        public override string ToString()
        {
            return Maximum == 1 ? "You may draw a card." : $"You may draw up to {Maximum} cards.";
        }
    }

    class YouMayDrawCardEffect : YouMayDrawCardsEffect
    {
        public YouMayDrawCardEffect() : base(1)
        {
        }

        public YouMayDrawCardEffect(YouMayDrawCardsEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDrawCardEffect(this);
        }
    }

    class YouMayDrawUpToTwoCardsEffect : YouMayDrawCardsEffect
    {
        public YouMayDrawUpToTwoCardsEffect() : base(2)
        {
        }

        public YouMayDrawUpToTwoCardsEffect(YouMayDrawUpToTwoCardsEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDrawUpToTwoCardsEffect(this);
        }
    }

    class YouMayDrawUpToThreeCardsEffect : YouMayDrawCardsEffect
    {
        public YouMayDrawUpToThreeCardsEffect() : base(3)
        {
        }

        public YouMayDrawUpToThreeCardsEffect(YouMayDrawUpToThreeCardsEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDrawUpToThreeCardsEffect(this);
        }
    }
}
