using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class MinelordSkyterror : SilentSkillCreature
{
    public MinelordSkyterror() : base("Minelord Skyterror", 4, 3000,
        Race.ArmoredWyvern, Civilization.Fire)
    {
        AddSilentSkillAbility(
            new CardMovingAreaOfEffect(
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                filter: new MaxPowerFilter(3000),
                selectionRange: SelectionRange.AllCards,
                excludeSource: false));
    }
}