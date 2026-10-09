using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;
using ContinuousEffects.Replacement;
using Interfaces;

namespace Cards.DM06;

public sealed class LuGilaSilverRiftGuardian : Creature
{
    public LuGilaSilverRiftGuardian() : base(
        "Lu Gila, Silver Rift Guardian", 5, 4000, Race.Guardian, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddStaticAbilities(new LuGilaEffect());
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}
