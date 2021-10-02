﻿using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Cards.Creatures;
using DuelMastersModels.GameEvents;
using DuelMastersModels.Steps;
using Moq;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class DuelTests
    {
        [Fact]
        public void GetAbilitiesThatTriggerFromPermanents_TriggerPyrofighterMagnusAbility_AbilityTriggers()
        {
            var player1 = new Player();
            var card = new Card();
            card.Abilities.Add(new PyrofighterMagnusAbility { Controller = player1.Id });
            player1.BattleZone.Permanents.Add(new Permanent(card) { Controller = player1.Id });
            var duel = new Duel();
            duel.Players.Add(player1);
            var turn = new Turn { ActivePlayer = player1.Id };
            turn.Steps.Add(Mock.Of<Step>());
            duel.Turns.Add(turn);
            var abilities = duel.GetAbilitiesThatTriggerFromPermanents(new TurnEndsEvent(turn.Id));
            _ = Assert.IsType<PyrofighterMagnusAbility>(abilities.Single());
        }
    }
}
