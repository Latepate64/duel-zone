using DuelMastersModels;
using DuelMastersModels.Choices;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator
{
    public class Simulator
    {
        public Duel PlayDuel(Player player1, Player player2, int choicesMax)
        {
            Duel duel = new();
            Choice choice = duel.Start(player1, player2);
            int numberOfChoicesMade = 0;
            int latestPoints = 0;
            while (choice != null)
            {
                var duelCopy = GetDuelForSimulator(duel, choice.Player);
                var simulation = new Simulation(choice.Player, choicesMax);
                var (decision, points) = simulation.Choose(choice, duelCopy, null, numberOfChoicesMade++);
                using (decision)
                {
                    latestPoints = points;
                    choice = duel.Continue(decision);
                }

                if (duel.Turns.Count > 200) // Could happen Corile vs Corile
                {
                    //TODO: Improve
                    while (duel.Players.Any())
                    {
                        duel.Lose(duel.Players.First());
                    }
                    return duel;
                }
            }
            return duel;
        }

        private Duel GetDuelForSimulator(Duel duel, Guid simulator)
        {
            var duelCopy = new Duel(duel);
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
