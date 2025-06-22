using Interfaces;

namespace Cards.DM11;

public class BaraidTheExplorer : SilentSkillCreature
{
    public BaraidTheExplorer() : base("Baraid, the Explorer", 5, 5000, Race.Gladiator, Civilization.Light)
    {
        AddSilentSkillAbility(new BaraidTheExplorerEffect());
    }
}
