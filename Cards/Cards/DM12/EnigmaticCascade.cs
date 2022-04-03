using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM12
{
    class EnigmaticCascade : Spell
    {
        public EnigmaticCascade() : base("Enigmatic Cascade", 4, Civilization.Water)
        {
            AddSpellAbilities(new EnigmaticCascadeEffect());
        }
    }

    class EnigmaticCascadeEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = new OneShotEffects.DiscardAnyNumberOfCardsEffect().Apply(game, source);
            source.GetController(game).DrawCards(cards.Count(), game);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new EnigmaticCascadeEffect();
        }

        public override string ToString()
        {
            return "Discard any number of cards from your hand. Then draw that many cards.";
        }
    }
}
