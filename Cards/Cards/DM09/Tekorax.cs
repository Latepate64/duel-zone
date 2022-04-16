using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM09
{
    class Tekorax : Creature
    {
        public Tekorax() : base("Tekorax", 5, 3000, Race.SeaHacker, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TekoraxEffect());
        }
    }

    class TekoraxEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = source.GetOpponent(game).ShieldZone.Cards;
            if (cards.Any())
            {
                source.GetController(game).Look(source.GetOpponent(game), game, cards.ToArray());
                source.GetOpponent(game).Unreveal(cards);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new TekoraxEffect();
        }

        public override string ToString()
        {
            return "Look at your opponent's shields. Then put them back where they were.";
        }
    }
}
