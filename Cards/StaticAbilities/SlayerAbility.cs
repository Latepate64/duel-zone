using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    public class SlayerAbility : StaticAbility
    {
        public SlayerAbility() : base(new SlayerEffect(new Engine.TargetFilter(), new CardFilters.BattleZoneCreatureFilter()))
        {
        }
    }
}
