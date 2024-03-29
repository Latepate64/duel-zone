﻿using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM09
{
    class NecrodragonIzoristVhal : Creature
    {
        public NecrodragonIzoristVhal() : base("Necrodragon Izorist Vhal", 6, 0, Race.ZombieDragon, Civilization.Darkness)
        {
            AddStaticAbilities(new NecrodragonIzoristVhalEffect(), new PoweredDoubleBreaker());
        }
    }

    class NecrodragonIzoristVhalEffect : PowerModifyingMultiplierEffect
    {
        public NecrodragonIzoristVhalEffect(int power = 2000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new NecrodragonIzoristVhalEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each darkness creature in your graveyard.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return Controller.Graveyard.GetCreatures(Civilization.Darkness).Count();
        }
    }
}
