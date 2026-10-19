using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class Vikorakys : TurboRushCreature
{
    public Vikorakys() : base("Vikorakys", 3, 1000, Race.SeaHacker,
        Civilization.Water)
    {
        AddTurboRushAbility(
            new WheneverThisCreatureAttacksAbility(
                new SearchEffect(
                    reveal: false,
                    filter: new AnyCardFilter()
            )));
    }
}