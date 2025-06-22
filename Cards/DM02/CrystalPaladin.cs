using TriggeredAbilities;
using Interfaces;

namespace Cards.DM02;

public class CrystalPaladin : EvolutionCreature
{
    public CrystalPaladin() : base("Crystal Paladin", 4, 5000, Race.LiquidPeople, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CrystalPaladinEffect()));
    }
}
