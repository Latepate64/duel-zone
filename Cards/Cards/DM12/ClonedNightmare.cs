using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

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

        public override object Apply(IGame game, IAbility source)
        {
            var number = source.GetController(game).ChooseNumber("Choose how many cards your opponent will discard at random from their hand.", 1, GetAmount(game));
            source.GetOpponent(game).DiscardAtRandom(game, number);
            return null;
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
}
