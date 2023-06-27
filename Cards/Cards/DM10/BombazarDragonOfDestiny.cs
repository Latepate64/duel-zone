﻿using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class BombazarDragonOfDestiny : Creature
    {
        public BombazarDragonOfDestiny() : base("Bombazar, Dragon of Destiny", 7, 6000, Race.ArmoredDragon, Race.EarthDragon, Civilization.Fire, Civilization.Nature)
        {
            AddSpeedAttackerAbility();
            AddDoubleBreakerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new BombazarDragonOfDestinyEffect());
        }
    }

    class BombazarDragonOfDestinyEffect : OneShotEffect
    {
        public BombazarDragonOfDestinyEffect()
        {
        }

        public BombazarDragonOfDestinyEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.Destroy(Ability, game.BattleZone.Creatures.Where(p => p != Ability.Source && p.Power.Value == 6000).ToArray());
            Turn turn = new() { ActivePlayer = Applier, NonActivePlayer = GetOpponent(game) };
            game.ExtraTurns.Push(turn);
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new AtTheEndOfTurnAbility(turn.Id, new YouLoseTheGameAtTheEndOfTheExtraTurnEffect()), Ability.Source, Ability.Controller, true));
        }

        public override IOneShotEffect Copy()
        {
            return new BombazarDragonOfDestinyEffect(this);
        }

        public override string ToString()
        {
            return "Destroy all other creatures that have power 6000, then take an extra turn after this one. You lose the game at the end of the extra turn.";
        }
    }

    class YouLoseTheGameAtTheEndOfTheExtraTurnEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.Lose(Applier);
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
