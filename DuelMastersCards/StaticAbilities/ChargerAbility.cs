using DuelMastersCards.CardFilters;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace DuelMastersCards.StaticAbilities
{
    public class ChargerAbility : StaticAbility
    {
        public ChargerAbility()
        {
            ContinuousEffects.Add(new ChargerEffect(new TargetFilter(), new Indefinite()));
            FunctionZone = DuelMastersModels.Zones.ZoneType.SpellStack;
        }

        public ChargerAbility(StaticAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new ChargerAbility(this);
        }
    }
}
