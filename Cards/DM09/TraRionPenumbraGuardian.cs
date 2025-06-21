using OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.DM09;

public class TraRionPenumbraGuardian : Creature
{
    public TraRionPenumbraGuardian() : base("Tra Rion, Penumbra Guardian", 6, 5500, Race.Guardian, Civilization.Light)
    {
        AddAbilities(new TapAbility(new TraRionPenumbraGuardianEffect()));
    }
}
