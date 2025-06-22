using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM12;

public sealed class UlarusPunishmentElemental : Creature
{
    public UlarusPunishmentElemental() : base(
        "Ularus, Punishment Elemental", 5, 4500, Race.AngelCommand, Civilization.Light)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new UlarusEffect()));
    }
}
