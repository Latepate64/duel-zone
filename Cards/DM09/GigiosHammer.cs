using Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class GigiosHammer : Creature
{
    public GigiosHammer() : base("Gigio's Hammer", 3, 2000, Race.Xenoparts, Civilization.Fire)
    {
        AddAbilities(new TapAbility(new GigiosHammerOneShotEffect()));
    }
}
