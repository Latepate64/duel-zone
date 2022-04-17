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
        public override object Apply(IGame game, IAbility source)
        {
            var number = source.GetController(game).ChooseNumber(new Engine.Choices.NumberChoice(source.GetController(game), ToString()));
            foreach (var player in new System.Guid[] { source.Controller, game.GetOpponent(source.Controller) })
            {
                game.GetPlayer(player).Reveal(game, game.GetPlayer(player).Hand.Cards.ToArray());
                game.Move(source, ZoneType.Hand, ZoneType.Graveyard, game.GetPlayer(player).Hand.Cards.Where(x => x.ManaCost == number).ToArray());
                game.GetPlayer(player).Unreveal(game.GetPlayer(player).Hand.Cards.ToArray());
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new RouletteOfRuinEffect();
        }

        public override string ToString()
        {
            return "Choose a number. Show your hand to your opponent and discard from it each card that has that cost. Then your opponent shows you his hand and discards from it each card that has that cost.";
        }
    }
}
