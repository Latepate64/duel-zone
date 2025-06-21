using TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM09;

public class MarchingMotherboard : Creature
{
    public MarchingMotherboard() : base("Marching Motherboard", 6, 2000, Race.CyberVirus, Civilization.Water)
    {
        AddTriggeredAbility(new MarchingMotherboardAbility(new OneShotEffects.YouMayDrawCardEffect()));
    }
}
