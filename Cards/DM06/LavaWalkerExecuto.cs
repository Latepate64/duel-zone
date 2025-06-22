using ContinuousEffects;
using Interfaces;

namespace Cards.DM06;

public sealed class LavaWalkerExecuto : EvolutionCreature
{
    public LavaWalkerExecuto() : base("Lava Walker Executo", 4, 5000, Race.Dragonoid, Civilization.Fire)
    {
        AddStaticAbilities(new TapAbilityAddingEffect(Civilization.Fire, new LavaWalkerExecutoEffect(3000)));
    }
}
