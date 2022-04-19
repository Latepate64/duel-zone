using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM05
{
    class CyclonePanic : Spell
    {
        public CyclonePanic() : base("Cyclone Panic", 3, Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(new CyclonePanicEffect());
        }
    }

    class CyclonePanicEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            game.Players.ToList().ForEach(x => Apply(x, game, source));
        }

        private static void Apply(IPlayer player, IGame game, IAbility source)
        {
            var amount = player.Hand.Cards.Count;
            game.Move(source, ZoneType.Hand, ZoneType.Deck, player.Hand.Cards.ToArray());
            player.ShuffleDeck(game);
            player.DrawCards(amount, game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new CyclonePanicEffect();
        }

        public override string ToString()
        {
            return "Each player counts the cards in his hand, shuffles these cards into his deck, then draws that many cards.";
        }
    }
}
