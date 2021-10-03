using DuelMastersCards;
using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Zones;
using Xunit;

namespace UnitTests
{
    public class AbilityTests
    {
        [Fact]
        public void PyrofighterMagnusAbility_Resolve_PermanentIsInBattleZone_CardGoesToHand()
        {
            var player = new Player();
            var card = new Card { Owner = player.Id };
            var ability = new PyrofighterMagnusAbility { Controller = player.Id };
            card.Abilities.Add(ability);
            var duel = new Duel();
            duel.Players.Add(player);
            duel.Players.Add(new Player());
            player.BattleZone = new BattleZone();
            var permanent = new Permanent(card) { Controller = player.Id };
            player.BattleZone.Permanents.Add(permanent);
            ability.Source = permanent.Id;
            _ = ability.Resolve(duel, null);
            Assert.Empty(player.BattleZone.Permanents);
            Assert.Contains(card, player.Hand.Cards);
            //}
        }
}
