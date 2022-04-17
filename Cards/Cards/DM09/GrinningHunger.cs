﻿using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM09
{
    class GrinningHunger : Spell
    {
        public GrinningHunger() : base("Grinning Hunger", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new GrinningHungerEffect());
        }
    }

    class GrinningHungerEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var opponent = source.GetOpponent(game);
            var card = opponent.ChooseCard(game.BattleZone.GetCreatures(opponent.Id).Union(opponent.ShieldZone.Cards), ToString());
            game.Move(source, game.GetZone(card).Type, ZoneType.Graveyard, card);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new GrinningHungerEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his creatures in the battle zone or one of his shields and puts it into his graveyard.";
        }
    }
}