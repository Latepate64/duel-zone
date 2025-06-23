using ContinuousEffects;
using Interfaces;

namespace Cards.DM10;

public sealed class MykeesPliers : Creature
{
    public MykeesPliers() : base("Mykee's Pliers", 4, 2000, Race.Xenoparts, Civilization.Fire)
    {
        AddStaticAbilities(new MykeesPliersEffect());
    }
}
