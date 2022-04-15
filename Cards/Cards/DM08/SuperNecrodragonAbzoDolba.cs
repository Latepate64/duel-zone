﻿using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM08
{
    class SuperNecrodragonAbzoDolba : DragonEvolutionCreature
    {
        public SuperNecrodragonAbzoDolba() : base("Super Necrodragon Abzo Dolba", 6, 11000, Engine.Subtype.ZombieDragon, Civilization.Darkness)
        {
            AddStaticAbilities(new SuperNecrodragonAbzoDolbaEffect());
            AddTripleBreakerAbility();
        }
    }

    class SuperNecrodragonAbzoDolbaEffect : ContinuousEffects.PowerModifyingMultiplierEffect
    {
        public SuperNecrodragonAbzoDolbaEffect() : base(2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SuperNecrodragonAbzoDolbaEffect();
        }

        public override string ToString()
        {
            return "This creature gets +2000 power for each creature in your graveyard.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return GetController(game).Graveyard.Creatures.Count();
        }
    }
}
