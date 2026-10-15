using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01;

public sealed class CreepingPlague : Spell
{
    public CreepingPlague() : base("Creeping Plague", 1, Civilization.Darkness)
    {
        AddSpellAbilities(
            new WheneverSomethingHappensThisTurnEffect(
                new WheneverSomethingHappensThisTurnAbilityFactory(),
                new CreepingPlagueTriggeredAbility()
            ));
    }
}
