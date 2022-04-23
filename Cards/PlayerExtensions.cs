using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards
{
    static class PlayerExtensions
    {
        public static void DestroyOpponentsBlocker(this IPlayer player, IGame game, IAbility source)
        {
            var blocker = player.ChooseCard(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, game.GetOpponent(player.Id)).Where(x => x.GetAbilities<BlockerAbility>().Any()), source.ToString());
            game.Destroy(source, blocker);
        }
    }
}
