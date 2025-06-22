using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class SimianWarriorGrash : Creature
{
    public SimianWarriorGrash() : base("Simian Warrior Grash", 4, 3000, Race.Armorloid, Civilization.Fire)
    {
        AddTriggeredAbility(new SimianWarriorGrashAbility(
            new OneShotEffects.YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect()));
    }
}
