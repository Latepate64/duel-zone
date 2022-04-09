using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class AsraVizierOfSafety : WaveStrikerCreature
    {
        public AsraVizierOfSafety() : base("Asra, Vizier of Safety", 3, 2000, Common.Subtype.Initiate, Common.Civilization.Light)
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
