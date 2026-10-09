using Abilities.Static;
using ContinuousEffects.CannotAttackPlayers;
using Interfaces;
using TriggeredAbilities;

namespace Cards.DM05;

public sealed class SnorkLaShrineGuardian : Creature
{
    public SnorkLaShrineGuardian() : base("Snork La, Shrine Guardian", 3, 3000, Race.Guardian, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        AddTriggeredAbility(new SnorkLaAbility());
    }
}
