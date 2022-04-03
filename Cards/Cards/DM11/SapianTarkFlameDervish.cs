using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM11
{
    class SapianTarkFlameDervish : WaveStrikerCreature
    {
        public SapianTarkFlameDervish() : base("Sapian Tark, Flame Dervish", 3, 2000, Subtype.Dragonoid, Civilization.Fire)
        {
            AddWaveStrikerAbility(new SapianTarkFlameDervishEffect());
        }
    }

    class SapianTarkFlameDervishEffect : ContinuousEffects.ThisCreatureCanAttackUntappedCreaturesEffect, IPowerModifyingEffect
    {
        public override IContinuousEffect Copy()
        {
            return new SapianTarkFlameDervishEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += 4000);
        }

        public override string ToString()
        {
            return "This creature gets +4000 power and can attack untapped creatures.";
        }
    }
}
