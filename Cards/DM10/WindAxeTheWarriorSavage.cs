using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class WindAxeTheWarriorSavage : Creature
{
    public WindAxeTheWarriorSavage() : base(
        "Wind Axe, the Warrior Savage", 5, 2000, [Race.Human, Race.BeastFolk], Civilization.Fire, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new WindAxeTheWarriorSavageEffect()));
    }
}
