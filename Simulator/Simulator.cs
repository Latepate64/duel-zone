using Engine;

namespace Simulator
{
    public class Simulator
    {
        public Game PlayDuel(Player player1, Player player2)
        {
            Game game = new();
            game.Play(player1, player2);
            return game;
        }
    }
}
