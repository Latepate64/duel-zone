using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class BaraidTheExplorer : SilentSkillCreature
{
    public BaraidTheExplorer() : base("Baraid, the Explorer", 5, 5000, Race.Gladiator, Civilization.Light)
    {
        AddSilentSkillAbility(new BaraidTheExplorerEffect());
    }
}
