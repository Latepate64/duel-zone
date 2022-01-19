using DuelMastersModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator
{
    public class Simulator
    {
        public Game PlayDuel(Player player1, Player player2, int choicesMax)
        {
            Game game = new();
            game.Play(player1, player2);
            //int numberOfChoicesMade = 0;
            //int latestPoints = 0;
            //while (choice != null)
            //{
            //    var duelCopy = GetDuelForSimulator(game, choice.Player);
            //    var simulation = new Simulation(choice.Player, choicesMax);
            //    var (decision, points) = simulation.Choose(choice, duelCopy, null, numberOfChoicesMade++);
            //    using (decision)
            //    {
            //        latestPoints = points;
            //        choice = game.Continue();
            //    }

            //    if (game.Turns.Count > 200) // Could happen Corile vs Corile
            //    {
            //        //TODO: Improve
            //        while (game.Players.Any())
            //        {
            //            game.Lose(game.Players.First());
            //        }
            //        return game;
            //    }
            //}
            return game;
        }

        private Game GetDuelForSimulator(Game game, Guid simulator)
        {
            var duelCopy = new Game(game);
            foreach (var card in duelCopy.Players.SelectMany(p => p.AllCards))
            {
                if (!card.RevealedTo.Contains(simulator))
                {
                    card.Abilities.Clear();
                    card.CardType = CardType.Spell;
                    card.Civilizations.Clear();
                    card.ManaCost = 999;
                    card.Name = "Unknown";
                    card.Power = null;
                    card.ShieldTrigger = false;
                    card.Subtypes = new List<Subtype>();
                }
            }
            return duelCopy;
        }
    }
}
