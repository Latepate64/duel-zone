using TriggeredAbilities;
using Engine;

namespace Cards.DM09;

public class SimianWarriorGrash : Creature
{
    public SimianWarriorGrash() : base("Simian Warrior Grash", 4, 3000, Race.Armorloid, Civilization.Fire)
    {
        AddTriggeredAbility(new SimianWarriorGrashAbility(
            new OneShotEffects.YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect()));
    }
}
