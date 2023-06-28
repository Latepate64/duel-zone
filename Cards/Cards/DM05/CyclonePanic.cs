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
        public override void Apply()
        {
            Game.Players.ToList().ForEach(x => Apply(x, Ability));
        }

        private void Apply(IPlayer player, IAbility source)
        {
            var amount = player.Hand.Cards.Count;
            Game.Move(source, ZoneType.Hand, ZoneType.Deck, player.Hand.Cards.ToArray());
            player.ShuffleOwnDeck();
            player.DrawCards(amount, source);
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
