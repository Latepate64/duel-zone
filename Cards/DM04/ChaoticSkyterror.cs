using Engine;
using Interfaces;

namespace Cards.DM04;

public class ChaoticSkyterror : Creature
{
    public ChaoticSkyterror() : base("Chaotic Skyterror", 5, 4000, Race.ArmoredWyvern, Civilization.Fire)
    {
        AddStaticAbilities(new ChaoticSkyterrorEffect());
    }
}
