using ContinuousEffects;
using Interfaces;

namespace Cards.DM06;

public sealed class LuGilaSilverRiftGuardian : Creature
{
    public LuGilaSilverRiftGuardian() : base(
        "Lu Gila, Silver Rift Guardian", 5, 4000, Race.Guardian, Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddStaticAbilities(new LuGilaEffect());
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}
