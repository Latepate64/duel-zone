using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class BlissTotemAvatarOfLuck : Creature
{
    public BlissTotemAvatarOfLuck() : base(
        "Bliss Totem, Avatar of Luck", 6, 5000, Race.MysteryTotem,
        Civilization.Nature)
    {
        AddAbilities(
            new TapAbility(
                new FromGraveyardIntoManaZoneEffect(
                    0, 3, true, new AnyCardFilter()
        )));
    }
}
