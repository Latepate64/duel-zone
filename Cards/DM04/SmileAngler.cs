using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM04;

public sealed class SmileAngler : Creature
{
    public SmileAngler() : base("Smile Angler", 6, 3000, Race.GelFish,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new ManaRecoveryEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    ownMana: false
        )));
    }
}
