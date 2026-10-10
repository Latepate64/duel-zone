using CardFilters;
using ContinuousEffects.Replacement;
using Interfaces;

namespace Cards.DM10;

public sealed class MysticMagician : Creature
{
    public MysticMagician() : base("Mystic Magician", 5, 3000, Race.Merfolk,
        Civilization.Water)
    {
        AddStaticAbilities(
            new YourCreaturesArePutIntoTheBattleZoneTappedEffect(
                new SilentSkillFilter()), 
            new WheneverOneOfYourCreaturesWouldBeDestroyedPutIntoIntoYourHandInsteadEffect(
                new SilentSkillFilter()));
    }
}
