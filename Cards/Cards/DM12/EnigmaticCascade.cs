using Engine;
using Engine.Abilities;

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
        public override void Apply()
        {
            var player = Applier;
            int amount = player.DiscardAnyNumberOfCards(Ability);
            player.DrawCards(amount, Ability);
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
