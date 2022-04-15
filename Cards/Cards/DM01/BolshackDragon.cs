﻿using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM01
{
    class BolshackDragon : Creature
    {
        public BolshackDragon() : base("Bolshack Dragon", 6, 6000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new BolshackDragonEffect(), new DoubleBreakerEffect());
        }
    }

    class BolshackDragonEffect : PowerAttackerMultiplierEffect
    {
        public BolshackDragonEffect() : base(1000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new BolshackDragonEffect();
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +1000 power for each fire card in your graveyard.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return GetController(game).Graveyard.GetCards(Civilization.Fire).Count();
        }
    }
}