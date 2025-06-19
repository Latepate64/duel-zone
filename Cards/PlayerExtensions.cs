using Abilities.Static;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards
{
    static class PlayerExtensions
    {
        public static void DestroyOpponentsBlocker(this Player player, IGame game, IAbility source)
        {
            var blocker = player.ChooseCard(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, game.GetOpponent(player.Id)).Where(x => x.IsBlocker()), source.ToString());
            game.Destroy(source, blocker);
        }

        public static bool IsBlocker(this Card card)
        {
            return card.GetAbilities<BlockerAbility>().Any();
        }
    }
}
