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
            var blocker = player.ChooseCard(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, player.Opponent.Id).Where(x => x.IsBlocker()), source.ToString());
            game.Destroy(source, blocker);
        }

        public static bool IsBlocker(this ICard card)
        {
            return card.GetAbilities<BlockerAbility>().Any();
        }
    }
}
