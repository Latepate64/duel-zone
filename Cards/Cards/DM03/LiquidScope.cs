using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM03
{
    class LiquidScope : Spell
    {
        public LiquidScope() : base("Liquid Scope", 4, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new LiquidScopeEffect());
        }
    }

    class LiquidScopeEffect : OneShotEffect
    {
        public LiquidScopeEffect()
        {
        }

        public LiquidScopeEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var opponent = GetOpponent(game);
            var cards = opponent.Hand.Cards.Union(opponent.ShieldZone.Cards).ToArray();
            if (cards.Any())
            {
                var revealer = game.GetOwner(cards.First());
                Applier.Look(revealer, game, cards);
                revealer.Unreveal(cards);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new LiquidScopeEffect(this);
        }

        public override string ToString()
        {
            return "Look at your opponent's hand and shields. Then put the shields back where they were.";
        }
    }
}
