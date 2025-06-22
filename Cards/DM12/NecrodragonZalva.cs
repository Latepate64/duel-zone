using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM12;

public sealed class NecrodragonZalva : Creature
{
    public NecrodragonZalva() : base("Necrodragon Zalva", 4, 5000, Race.ZombieDragon, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new NecrodragonZalvaEffect()));
    }
}
