using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM07;

public sealed class TrenchdiveShark : Creature
{
    public TrenchdiveShark() : base("Trenchdive Shark", 7, 5000, Race.GelFish, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TrenchdiveSharkEffect()));
    }
}
