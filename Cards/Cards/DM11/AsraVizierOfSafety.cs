using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class AsraVizierOfSafety : WaveStrikerCreature
    {
        public AsraVizierOfSafety() : base("Asra, Vizier of Safety", 3, 2000, Race.Initiate, Civilization.Light)
        {
            AddWaveStrikerAbility(new AsraVizierOfSafetyEffect());
        }
    }

    class AsraVizierOfSafetyEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public AsraVizierOfSafetyEffect() : base() { }

        public AsraVizierOfSafetyEffect(AsraVizierOfSafetyEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            GetSourceCard(game).AddGrantedAbility(new StaticAbilities.BlockerAbility());
        }

        public override IContinuousEffect Copy()
        {
            return new AsraVizierOfSafetyEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            GetSourceCard(game).Power += 4000;
        }

        public override string ToString()
        {
            return "This creature gets +4000 power and has \"Blocker.\"";
        }
    }
}
