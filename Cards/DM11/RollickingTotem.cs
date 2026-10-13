using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class RollickingTotem : SilentSkillCreature
{
    private const string RollickingTotemName = "Rollicking Totem";

    public RollickingTotem() : base(RollickingTotemName, 5, 4000,
        Race.MysteryTotem, Civilization.Nature)
    {
        AddSilentSkillAbility(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new NameFilter(RollickingTotemName),
                source: ZoneType.ManaZone,
                destination: ZoneType.BattleZone
        ));
    }
}
