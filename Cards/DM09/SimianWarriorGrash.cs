using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM09;

public sealed class SimianWarriorGrash : Creature
{
    public SimianWarriorGrash() : base("Simian Warrior Grash", 4, 3000,
        Race.Armorloid, Civilization.Fire)
    {
        AddTriggeredAbility(
            new SimianWarriorGrashAbility(
                new ManaBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: false,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
        )));
    }
}
