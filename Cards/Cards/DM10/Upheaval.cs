﻿using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class Upheaval : Spell
    {
        public Upheaval() : base("Upheaval", 6, Civilization.Darkness)
        {
            AddShieldTrigger();
            AddSpellAbilities(new UpheavalEffect());
        }
    }

    class UpheavalEffect : OneShotEffect
    {
        public UpheavalEffect()
        {
        }

        public UpheavalEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var mana = Game.Players.SelectMany(x => x.ManaZone.Cards);
            var hand = Game.Players.SelectMany(x => x.Hand.Cards);
            Game.Move(Ability, ZoneType.ManaZone, ZoneType.Hand, mana.ToArray());
            Game.MoveTapped(Ability, ZoneType.Hand, ZoneType.ManaZone, hand.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new UpheavalEffect(this);
        }

        public override string ToString()
        {
            return "Each player puts all the cards from his mana zone into his hand and, at the same time, puts all the cards from his hand into his mana zone tapped.";
        }
    }
}
