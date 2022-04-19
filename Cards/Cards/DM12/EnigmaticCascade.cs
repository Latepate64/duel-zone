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
        public override void Apply(IGame game, IAbility source)
        {
            var player = source.GetController(game);
            int amount = player.DiscardAnyNumberOfCards(game, source);
            player.DrawCards(amount, game, source);
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
