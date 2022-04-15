﻿using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class NecrodragonIzoristVhal : Creature
    {
        public NecrodragonIzoristVhal() : base("Necrodragon Izorist Vhal", 6, 0, Engine.Subtype.ZombieDragon, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new NecrodragonIzoristVhalEffect(), new PoweredDoubleBreaker());
        }
    }

    class NecrodragonIzoristVhalEffect : PowerModifyingMultiplierEffect
    {
        public NecrodragonIzoristVhalEffect() : base(2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new NecrodragonIzoristVhalEffect();
        }

        public override string ToString()
        {
            return "This creature gets +2000 power for each darkness creature in your graveyard.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return GetController(game).Graveyard.GetCreatures(Engine.Civilization.Darkness).Count();
        }
    }
}
