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

        public override object Apply(IGame game, IAbility source)
        {
            var opponent = source.GetOpponent(game);
            var cards = opponent.Hand.Cards.Union(opponent.ShieldZone.Cards);
            if (cards.Any())
            {
                var revealer = game.GetOwner(cards.First());
                source.GetController(game).Look(revealer, game, cards.ToArray());
                revealer.Unreveal(cards);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new LiquidScopeEffect();
        }

        public override string ToString()
        {
            return "Look at your opponent's hand and shields. Then put the shields back where they were.";
        }
    }
}
