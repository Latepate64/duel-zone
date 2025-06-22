using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM10;

public class WindAxeTheWarriorSavage : Creature
{
    public WindAxeTheWarriorSavage() : base(
        "Wind Axe, the Warrior Savage", 5, 2000, [Race.Human, Race.BeastFolk], Civilization.Fire, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new WindAxeTheWarriorSavageEffect()));
    }
}
