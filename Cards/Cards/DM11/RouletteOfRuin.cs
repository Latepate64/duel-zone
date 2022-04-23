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

        public override void Apply(IGame game)
        {
            var number = Controller.ChooseNumber(new Engine.Choices.NumberChoice(Controller, ToString()));
            foreach (var player in new System.Guid[] { Ability.Controller.Id, game.GetOpponent(Ability.Controller.Id) })
            {
                game.GetPlayer(player).Reveal(game, game.GetPlayer(player).Hand.Cards.ToArray());
                game.Move(Ability, ZoneType.Hand, ZoneType.Graveyard, game.GetPlayer(player).Hand.Cards.Where(x => x.ManaCost == number).ToArray());
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
