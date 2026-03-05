using ContinuousEffects;
using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class HeadlongGiant : Creature
{
    public HeadlongGiant() : base("Headlong Giant", 9, 14000, Race.Giant, Civilization.Nature)
    {
        AddStaticAbilities(new HeadlongGiantEffect(), new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(
            4000));
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new DiscardCardFromYourHandEffect()));
        AddStaticAbilities(new TripleBreakerEffect());
    }
}
