using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM08
{
    class GrapeGlobbo : Creature
    {
        public GrapeGlobbo() : base("Grape Globbo", 2, 1000, Race.CyberVirus, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new LookAtYourOpponentsHandEffect());
        }
    }

    class LookAtYourOpponentsHandEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = source.GetOpponent(game).Hand.Cards;
            if (cards.Any())
            {
                source.GetController(game).Look(source.GetOpponent(game), game, cards.ToArray());
                source.GetOpponent(game).Unreveal(cards);
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new LookAtYourOpponentsHandEffect();
        }

        public override string ToString()
        {
            return "Look at your opponent's hand.";
        }
    }
}
