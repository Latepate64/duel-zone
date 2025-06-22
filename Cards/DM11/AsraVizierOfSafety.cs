using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM11
{
    sealed class AsraVizierOfSafety : WaveStrikerCreature
    {
        public AsraVizierOfSafety() : base("Asra, Vizier of Safety", 3, 2000, Race.Initiate, Civilization.Light)
        {
            AddWaveStrikerAbility(new AsraVizierOfSafetyEffect());
        }
    }

    sealed class AsraVizierOfSafetyEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public AsraVizierOfSafetyEffect() : base() { }

        public AsraVizierOfSafetyEffect(AsraVizierOfSafetyEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            Source.AddGrantedAbility(new StaticAbility(new ThisCreatureHasBlockerEffect()));
        }

        public override IContinuousEffect Copy()
        {
            return new AsraVizierOfSafetyEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            (Source as Creature).IncreasePower(4000);
        }

        public override string ToString()
        {
            return "This creature gets +4000 power and has \"Blocker.\"";
        }
    }
}
