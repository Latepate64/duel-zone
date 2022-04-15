using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class CalgoVizierOfRainclouds : Creature
    {
        public CalgoVizierOfRainclouds() : base("Calgo, Vizier of Rainclouds", 3, 2000, Engine.Subtype.Initiate, Civilization.Light)
        {
            AddStaticAbilities(new CalgoVizierOfRaincloudsEffect());
        }
    }

    class CalgoVizierOfRaincloudsEffect : ContinuousEffect, IUnblockableEffect
    {
        public CalgoVizierOfRaincloudsEffect() : base()
        {
        }

        public bool Applies(Engine.ICard attacker, Engine.ICard blocker, IGame game)
        {
            return IsSourceOfAbility(attacker, game) && blocker.Power >= 4000;
        }

        public override IContinuousEffect Copy()
        {
            return new CalgoVizierOfRaincloudsEffect();
        }

        public override string ToString()
        {
            return "This creature can't be blocked by creatures that have power 4000 or more.";
        }
    }
}
