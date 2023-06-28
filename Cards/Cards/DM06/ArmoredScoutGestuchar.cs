﻿using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM06
{
    class ArmoredScoutGestuchar : Creature
    {
        public ArmoredScoutGestuchar() : base("Armored Scout Gestuchar", 5, 4000, Race.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new ArmoredScoutGestucharEffect());
        }
    }

    class ArmoredScoutGestucharEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public ArmoredScoutGestucharEffect()
        {
        }

        public ArmoredScoutGestucharEffect(ArmoredScoutGestucharEffect effect) : base(effect)
        {
        }

        public void AddAbility()
        {
            if (!Game.BattleZone.GetOtherCreatures(Applier, Source, Civilization.Fire).Any())
            {
                Source.AddGrantedAbility(new PowerAttackerAbility(3000));
                Source.AddGrantedAbility(new DoubleBreakerAbility());
            }
        }

        public override IContinuousEffect Copy()
        {
            return new ArmoredScoutGestucharEffect(this);
        }

        public override string ToString()
        {
            return "While you have no other fire creatures in the battle zone, this creature has \"power attacker +3000\" and \"double breaker.\"";
        }
    }
}
