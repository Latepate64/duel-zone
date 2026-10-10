using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM04;

public sealed class ThreeEyedDragonfly : Creature
{
    public ThreeEyedDragonfly() : base("Three-Eyed Dragonfly", 5, 4000,
        Race.GiantInsect, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new YouMaySacrificeAnotherCreatureIfYouDoThisCreatureGetsPowerAndDoubleBreakerUntilEndOfTurnEffect(
                    2000,
                    new CreatureFilter())));
    }
}
