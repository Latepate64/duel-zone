using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM10;

public sealed class CarnivalTotem : Creature
{
    public CarnivalTotem() : base("Carnival Totem", 6, 7000, Race.MysteryTotem, Civilization.Nature)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CarnivalTotemEffect()));
    }
}
