using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class UlexTheDauntless : Creature
{
    public UlexTheDauntless() : base(
        "Ulex, the Dauntless", 3, 3000, Race.SpiritQuartz, Civilization.Darkness, Civilization.Fire)
    {
        AddStaticAbilities(new YourOpponentCannotTapThisCreatureEffect());
    }
}
