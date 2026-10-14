using Abilities.Static;
using ContinuousEffects.CannotAttackCreatures;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

sealed class AvalancheGiant : Creature
{
    public AvalancheGiant() : base("Avalanche Giant", 6, 8000, Race.Giant,
        Civilization.Nature)
    {
        AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
        AddTriggeredAbility(
            new WheneverThisCreatureBecomesBlockedAbility(
                new ThisCreatureBreaksOpponentsShieldsEffect(1)));
        AddAbilities(new DoubleBreakerAbility());
    }
}