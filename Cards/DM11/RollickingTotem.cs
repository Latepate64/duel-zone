using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class RollickingTotem : SilentSkillCreature
{
    public RollickingTotem() : base("Rollicking Totem", 5, 4000, Race.MysteryTotem, Civilization.Nature)
    {
        AddSilentSkillAbility(new RollickingTotemEffect());
    }
}
