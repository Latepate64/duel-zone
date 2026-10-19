using StaticAbilities;
using ContinuousEffects.Unblockable;
using CardFilters;
using Interfaces;

namespace Cards.DM04
{
    sealed class AncientGiant : Creature
    {
        public AncientGiant() : base("Ancient Giant", 8, 9000, Race.Giant, Civilization.Nature)
        {
            AddStaticAbilities(
                new ThisCreatureCannotBeBlockedEffect(
                    new CivilizationCreatureFilter(
                        Civilization.Darkness)));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
