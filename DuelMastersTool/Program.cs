using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;

namespace DuelMastersTool
{
    /// <summary>
    /// A simple command line tool for testing DuelMastersModels.
    /// </summary>
    public static class Program
    {
        private static void Main(string[] args)
        {
            var jsonPath = "C:\\duel-masters-json\\DuelMastersCards.json";
            if (args.Length == 1)
            {
                jsonPath = args[0];
            }
            if (args.Length > 1)
            {
                throw new ArgumentOutOfRangeException("args");
            }
            else
            {
                var jsonCards = JsonCardFactory.GetJsonCards(jsonPath);
                var cards = CardFactory.GetCardsFromJsonCards(jsonCards);
                var duel = new Duel()
                {
                    Player1 = new Player()
                    {
                        Name = "Shobu",
                    },
                    Player2 = new AIPlayer()
                    {
                        Name = "Kokujo",
                    },
                };

                duel.Turns.CollectionChanged += TurnChanged;

                var count = 20;
                duel.Player1.SetDeckBeforeDuel(new Collection<Card>(cards.ToList().GetRange(0, count)));
                duel.Player2.SetDeckBeforeDuel(new Collection<Card>(cards.ToList().GetRange(count, count)));
                duel.Player1.SetupDeck();
                duel.Player2.SetupDeck();
                var playerAction = duel.StartDuel();

                while (playerAction != null)
                {
                    PerformPlayerAction(duel, playerAction);
                    playerAction = duel.Progress();
                }

                Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "{0} won the duel!", duel.Winner.Name));
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static void TurnChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (Turn turn in e.NewItems)
            {
                WriteLineWithEquals();
                Console.WriteLine("Turn number {0} started, active player: {1}, nonactive player: {2}", turn.Number, turn.ActivePlayer.Name, turn.NonActivePlayer.Name);
                turn.Steps.CollectionChanged += StepChanged;
            }
        }

        private static void StepChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (Step step in e.NewItems)
            {
                //WriteLineWithDashes();
                Console.WriteLine("{0} step started.", step.Name);
                step.PlayerActions.CollectionChanged += PlayerActionPerformed;
            }
        }

        private static void PlayerActionPerformed(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (PlayerAction playerAction in e.NewItems)
            {
                WriteLineWithBracket("Player action", playerAction.Message);
            }
        }

        private static void PerformPlayerAction(Duel duel, PlayerAction playerAction)
        {
            if (playerAction is CardSelection cardSelection)
            {
                CardSelection(cardSelection);
            }
            else if (playerAction is CreatureSelection creatureSelection)
            {
                CreatureSelection(creatureSelection);
            }
            else if (playerAction is UseCardPayRemainingMana useCardPayRemainingMana)
            {
                SelectCards(useCardPayRemainingMana);
            }
            else
            {
                throw new ArgumentOutOfRangeException("playerAction");
            }
            Console.WriteLine();
            playerAction.Perform(duel);
            duel.CurrentTurn.CurrentStep.PlayerActions.Add(playerAction);
        }

        private static void CardSelection(CardSelection cardSelection)
        {
            int index;
            if (cardSelection is ChargeMana chargeMana)
            {
                index = SelectCardOptional("Which card do you want to put into your mana zone?", chargeMana);
            }
            else if (cardSelection is UseCardDeclaration useCardDeclaration)
            {
                index = SelectCardOptional("Which card do you want to use?", useCardDeclaration);
            }
            else if (cardSelection is UseCardPayCivilization useCardPayCivilization)
            {
                index = SelectCard("Which mana do you want to use to pay the civilization of the card to be used?", useCardPayCivilization);
            }
            else
            {
                throw new ArgumentOutOfRangeException("cardSelection");
            }
            if (index <= cardSelection.Cards.Count())
            {
                cardSelection.SelectedCard = cardSelection.Cards[index - 1];
            }
        }

        private static void CreatureSelection(CreatureSelection creatureSelection)
        {
            int index;
            if (creatureSelection is DeclareAttacker declareAttacker)
            {
                index = SelectCreatureOptional("Which creature do you want to declare as an attacker?", declareAttacker, "None");
            }
            else if (creatureSelection is DeclareTargetOfAttack declareTargetOfAttack)
            {
                index = SelectCreatureOptional("Which creature do you want to attack?", declareTargetOfAttack, "Attack opponent");
            }
            else
            {
                throw new ArgumentOutOfRangeException("creatureSelection");
            }
            if (index <= creatureSelection.Creatures.Count())
            {
                creatureSelection.SelectedCreature = creatureSelection.Creatures[index - 1];
            }
        }

        #region Select
        private static int SelectCard(string question, CardSelection cardSelection)
        {
            WriteLineWithBracket(cardSelection.Player.Name, question);
            var index = 1;
            foreach (var card in cardSelection.Cards)
            {
                WriteLineWithBracket(index++, card.Name);
            }
            while (true)
            {
                var consoleKeyInfo = Console.ReadKey();
                if (Int32.TryParse(consoleKeyInfo.KeyChar.ToString(), out int number) && number <= cardSelection.Cards.Count)
                {
                    return number;
                }
            }
        }

        private static int SelectCardOptional(string question, CardSelection cardSelection)
        {
            WriteLineWithBracket(cardSelection.Player.Name, question);
            var index = 1;
            foreach (var card in cardSelection.Cards)
            {
                WriteLineWithBracket(index++, card.Name);
            }
            WriteLineWithBracket(index++, "None");
            while (true)
            {
                var consoleKeyInfo = Console.ReadKey();
                if (Int32.TryParse(consoleKeyInfo.KeyChar.ToString(), out int number) && number <= cardSelection.Cards.Count + 1)
                {
                    return number;
                }
            }
        }

        private static int SelectCreatureOptional(string question, CreatureSelection creatureSelection, string option)
        {
            WriteLineWithBracket(creatureSelection.Player.Name, question);
            var index = 1;
            foreach (var card in creatureSelection.Creatures)
            {
                WriteLineWithBracket(index++, card.Name);
            }
            WriteLineWithBracket(index++, option);
            while (true)
            {
                var consoleKeyInfo = Console.ReadKey();
                if (Int32.TryParse(consoleKeyInfo.KeyChar.ToString(), out int number) && number <= creatureSelection.Creatures.Count + 1)
                {
                    return number;
                }
            }
        }

        private static void SelectCards(UseCardPayRemainingMana useCardPayRemainingMana)
        {
            WriteLineWithBracket(useCardPayRemainingMana.Player.Name, String.Format(CultureInfo.InvariantCulture, "Select {0} mana to pay the remaining cost.", useCardPayRemainingMana.PayAmount));
            var index = 1;
            foreach (var card in useCardPayRemainingMana.ManaCards)
            {
                WriteLineWithBracket(index++, card.Name);
            }
            while (true)
            {
                var line = Console.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    var indices = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct().Select(i => Int32.Parse(i, CultureInfo.InvariantCulture)).Where(i => i <= useCardPayRemainingMana.ManaCards.Count());
                    if (indices.Count() == useCardPayRemainingMana.PayAmount)
                    {
                        foreach (var manaIndex in indices)
                        {
                            useCardPayRemainingMana.SelectedCards.Add(useCardPayRemainingMana.ManaCards[manaIndex - 1]);
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("The cost ({0}) and the number of legal distinct indices ({1}) didn't match.", useCardPayRemainingMana.PayAmount, indices.Count());
                    }
                }
                Console.WriteLine("The indices must be distinct, legal and separated with spaces.");
            }
        }
        #endregion Select

        #region WriteLine
        /*private static void WriteLineWithDashes()
        {
            WriteLineWithCharacters('-');
        }*/

        private static void WriteLineWithEquals()
        {
            WriteLineWithCharacters('=');
        }

        private static void WriteLineWithCharacters(char character)
        {
            var line = "";
            for (var i = 0; i < 100; ++i)
            {
                line += character;
            }
            Console.WriteLine(line);
        }

        private static void WriteLineWithBracket(int bracketNumber, string text)
        {
            WriteLineWithBracket(bracketNumber.ToString(CultureInfo.InvariantCulture), text);
        }

        private static void WriteLineWithBracket(string bracketText, string text)
        {
            Console.WriteLine("[{0}] {1}", bracketText, text);
        }
        #endregion WriteLine
    }
}
