using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class BurnwispLizard : Creature
{
    public BurnwispLizard() : base("Burnwisp Lizard", 5, 4000, Race.MeltWarrior, Civilization.Fire)
    {
        AddStaticAbilities(new BurnwispLizardEffect());
    }
}
