using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.Choices;

namespace Cards.Cards.DM12
{
    class ClonedNightmare : Spell
    {
        public ClonedNightmare() : base("Cloned Nightmare", 3, Civilization.Darkness)
        {
            AddSpellAbilities(new ClonedNightmareEffect(Name));
        }
    }

    class ClonedNightmareEffect : ClonedEffect
    {
        public ClonedNightmareEffect(string name) : base(name)
        {
        }

        public ClonedNightmareEffect(ClonedNightmareEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game, IAbility source)
        {
            var number = GetAmount(game);
            if (number > 1)
            {
                number = GetController(game).ChooseNumber(new ClonedNightmareChoice(GetController(game), "Choose how many cards your opponent will discard at random from their hand.", number));
            }
            GetOpponent(game).DiscardAtRandom(game, number, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedNightmareEffect(this);
        }

        public override string ToString()
        {
            return "Choose a card at random from opponent's hand. Then, for each Cloned Nightmare in each graveyard, you may choose another card at random from opponent's hand. Your opponent discards all those cards.";
        }
    }

    class ClonedNightmareChoice : NumberChoice
    {
        private readonly int _max;

        public ClonedNightmareChoice(ClonedNightmareChoice choice) : base(choice)
        {
            _max = choice._max;
        }

        public ClonedNightmareChoice(IPlayer maker, string description, int max) : base(maker, description)
        {
            _max = max;
        }

        public override bool IsValid()
        {
            return base.IsValid() && Choice >= 1 && Choice <= _max;
        }
    }
}
