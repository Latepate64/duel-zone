using Abilities.Static;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM08;

public sealed class MissileSoldierUltimo : TurboRushCreature
{
    public MissileSoldierUltimo(PowerAttackerAbilityFactory powerAttackerFactory)
    : base("Missile Soldier Ultimo", 3, 2000, Race.Dragonoid, Civilization.Fire)
    {
        AddTurboRushAbility(
            new ThisCreatureCanAttackUntappedCreaturesAndHasAbilityEffect(
                powerAttackerFactory, 4000));
    }
}
