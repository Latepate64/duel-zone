using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

public sealed class PalaOlesisMorningGuardian : Creature
{
    public PalaOlesisMorningGuardian() : base(
        "Pala Olesis, Morning Guardian", 3, 2500, Race.Guardian, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddStaticAbilities(new PalaOlesisMorningGuardianEffect());
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}
