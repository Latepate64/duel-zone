using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using ContinuousEffects.CannotAttack;
using ContinuousEffects.Unblockable;
using Abilities.Static;

namespace Cards.DM07;

sealed class HeadlongGiant : Creature
{
    public HeadlongGiant() : base("Headlong Giant", 9, 14000, Race.Giant, Civilization.Nature)
    {
        AddStaticAbilities(new HeadlongGiantEffect(), new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(
            4000));
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new DiscardCardFromYourHandEffect()));
        AddAbilities(new TripleBreakerAbility());
    }
}
