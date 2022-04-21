using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class RouletteOfRuin : Spell
    {
        public RouletteOfRuin() : base("Roulette of Ruin", 5, Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new RouletteOfRuinEffect());
        }
    }

    class RouletteOfRuinEffect : OneShotEffect
    {
        public RouletteOfRuinEffect()
        {
        }

        public RouletteOfRuinEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game, IAbility source)
        {
            var number = GetController(game).ChooseNumber(new Engine.Choices.NumberChoice(GetController(game), ToString()));
            foreach (var player in new System.Guid[] { source.Controller, game.GetOpponent(source.Controller) })
            {
                game.GetPlayer(player).Reveal(game, game.GetPlayer(player).Hand.Cards.ToArray());
                game.Move(source, ZoneType.Hand, ZoneType.Graveyard, game.GetPlayer(player).Hand.Cards.Where(x => x.ManaCost == number).ToArray());
                game.GetPlayer(player).Unreveal(game.GetPlayer(player).Hand.Cards.ToArray());
            }
        }

        public override IOneShotEffect Copy()
        {
            return new RouletteOfRuinEffect(this);
        }

        public override string ToString()
        {
            return "Choose a number. Show your hand to your opponent and discard from it each card that has that cost. Then your opponent shows you his hand and discards from it each card that has that cost.";
        }
    }
}
