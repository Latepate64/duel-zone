using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class CavernRaider : Creature
{
    public CavernRaider() : base("Cavern Raider", 3, 2000, Race.BeastFolk,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new CreatureFilter()
        )));
    }
}