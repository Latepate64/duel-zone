using TriggeredAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class CarnivalTotem : Creature
{
    public CarnivalTotem() : base("Carnival Totem", 6, 7000, Race.MysteryTotem, Civilization.Nature)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new CarnivalTotemEffect()));
    }
}
