using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM10;

public class SkyswordTheSavageVizier : Creature
{
    public SkyswordTheSavageVizier() : base("Skysword, the Savage Vizier", 5, 2000, [Race.BeastFolk, Race.Initiate],
        Civilization.Light, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SkyswordTheSavageVizierEffect()));
    }
}
