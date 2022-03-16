using Cards.CardFilters;
using Cards.StaticAbilities;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class MaskedPomegranate : Creature
    {
        public MaskedPomegranate() : base("Masked Pomegranate", 5, 1000, Subtype.TreeFolk, Civilization.Nature)
        {
            AddAbilities(new StaticAbility(new ContinuousEffects.PowerModifyingMultiplierEffect(1000, new OwnersBattleZoneCivilizationCreatureExceptFilter(Civilization.Nature))), new UnblockableAbility(new BattleZoneMaxPowerCreatureFilter(4000)));
        }
    }
}
