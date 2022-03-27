﻿using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class BombazarDragonOfDestiny : Creature
    {
        public BombazarDragonOfDestiny() : base("Bombazar, Dragon of Destiny", 7, 6000, Civilization.Fire, Civilization.Nature)
        {
            AddSubtypes(Subtype.ArmoredDragon, Subtype.EarthDragon);
            AddAbilities(new SpeedAttackerAbility(), new DoubleBreakerAbility(), new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BombazarDragonOfDestinyEffect()));
        }
    }

    class BombazarDragonOfDestinyEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            // When you put this creature into the battle zone, destroy all other creatures that have power 6000,
            game.Destroy(game.BattleZone.Creatures.Where(p => p.Id != source.Source && p.Power.Value == 6000).ToList());
            // then take an extra turn after this one.
            var owner = game.GetPlayer(source.Controller);
            Engine.Turn turn = new() { ActivePlayer = owner, NonActivePlayer = game.GetOpponent(owner) };
            game.ExtraTurns.Push(turn);
            // You lose the game at the end of the extra turn.
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new AtTheEndOfTurnAbility(turn.Id, new YouLoseTheGameAtTheEndOfTheExtraTurnEffect()), source.Source, source.Controller, new Durations.Indefinite(), true));
            return true;
        }

        public override IOneShotEffect Copy()
        {
            return new BombazarDragonOfDestinyEffect();
        }

        public override string ToString()
        {
            return "Destroy all other creatures that have power 6000, then take an extra turn after this one. You lose the game at the end of the extra turn.";
        }
    }

    class YouLoseTheGameAtTheEndOfTheExtraTurnEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.Lose(game.GetPlayer(source.Controller));
            return true;
        }

        public override IOneShotEffect Copy()
        {
            return new YouLoseTheGameAtTheEndOfTheExtraTurnEffect();
        }

        public override string ToString()
        {
            return "You lose the game.";
        }
    }
}
