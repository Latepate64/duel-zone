using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM03
{
    class PsychicShaper : Spell
    {
        public PsychicShaper() : base("Psychic Shaper", 6, Civilization.Water)
        {
            AddSpellAbilities(new PsychicShaperEffect());
        }
    }

    class PsychicShaperEffect : OneShotEffect
    {
        public PsychicShaperEffect()
        {
        }

        public PsychicShaperEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var cards = Controller.RevealTopCardsOfDeck(4, game);
            game.Move(Source, ZoneType.Deck, ZoneType.Hand, cards.Where(x => x.HasCivilization(Civilization.Water)).ToArray());
            game.Move(Source, ZoneType.Deck, ZoneType.Graveyard, cards.Where(x => !x.HasCivilization(Civilization.Water)).ToArray());
            Controller.Unreveal(cards);
        }

        public override IOneShotEffect Copy()
        {
            return new PsychicShaperEffect(this);
        }

        public override string ToString()
        {
            return "Reveal the top 4 cards of your deck. Put all water cards from among them into your hand and the rest into your graveyard.";
        }
    }
}
