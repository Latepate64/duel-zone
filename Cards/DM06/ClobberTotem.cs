using StaticAbilities;
using ContinuousEffects.PowerModifying;
using ContinuousEffects.Unblockable;
using CardFilters;

namespace Cards.DM06
{
    sealed class ClobberTotem : Creature
    {
        public ClobberTotem() : base("Clobber Totem", 6, 4000, Interfaces.Race.MysteryTotem, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect(new MaxPowerFilter(5000)));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
