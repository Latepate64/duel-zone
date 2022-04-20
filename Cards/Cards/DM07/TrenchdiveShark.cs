using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM07
{
    class TrenchdiveShark : Creature
    {
        public TrenchdiveShark() : base("Trenchdive Shark", 7, 5000, Race.GelFish, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TrenchdiveSharkEffect());
        }
    }

    class TrenchdiveSharkEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var player = source.GetController(game);
            var cards = player.ChooseCards(player.Hand.Cards, 0, 2, ToString());
            if (cards.Any())
            {
                game.Move(source, ZoneType.Hand, ZoneType.ShieldZone, cards.ToArray());
                var shields = player.ChooseCards(player.ShieldZone.Cards, cards.Count(), cards.Count(), ToString());
                game.Move(source, ZoneType.ShieldZone, ZoneType.Hand, shields.ToArray());
            }
        }

        public override IOneShotEffect Copy()
        {
            return new TrenchdiveSharkEffect();
        }

        public override string ToString()
        {
            return "You may add up to 2 cards from your hand to your shields face down. If you do, choose the same number of your shields and put them into your hand. You can't use the \"shield trigger\" ability of those shields.";
        }
    }
}
