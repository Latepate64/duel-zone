using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayDrawCardsEffect : OneShotEffect
    {
        public int Maximum { get; }

        public YouMayDrawCardsEffect(int maximum) : base()
        {
            Maximum = maximum;
        }

        public YouMayDrawCardsEffect(YouMayDrawCardsEffect effect)
        {
            Maximum = effect.Maximum;
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDrawCardsEffect(this);
        }

        public override void Apply(IGame game)
        {
            GetController(game).DrawCardsOptionally(game, GetSourceAbility(game), Maximum);
        }

        public override string ToString()
        {
            return Maximum == 1 ? "You may draw a card." : $"You may draw up to {Maximum} cards.";
        }
    }
}
