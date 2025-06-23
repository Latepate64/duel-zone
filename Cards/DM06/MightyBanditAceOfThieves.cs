using Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class MightyBanditAceOfThieves : Creature
{
    public MightyBanditAceOfThieves() : base(
        "Mighty Bandit, Ace of Thieves", 3, 2000, Race.BeastFolk, Civilization.Nature)
    {
        AddAbilities(new TapAbility(new MightyBanditAceOfThievesEffect()));
    }
}
