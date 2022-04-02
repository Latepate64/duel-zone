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
        public AsraVizierOfSafetyEffect() : base(new TargetFilter(), new Durations.Indefinite()) { }

        public AsraVizierOfSafetyEffect(AsraVizierOfSafetyEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.AddGrantedAbility(new StaticAbilities.BlockerAbility()));
        }

        public override IContinuousEffect Copy()
        {
            return new AsraVizierOfSafetyEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += 4000);
        }

        public override string ToString()
        {
            return "This creature gets +4000 power and has \"Blocker.\"";
        }
    }
}
