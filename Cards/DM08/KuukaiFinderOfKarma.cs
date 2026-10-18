using StaticAbilities;
using ContinuousEffects.CannotAttackPlayers;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class KuukaiFinderOfKarma : EvolutionCreature
{
    public KuukaiFinderOfKarma() : base("Kuukai, Finder of Karma", 5, 10500,
        Race.MechaThunder, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(
            new WheneverThisCreatureBlocksAbility(
                new AfterBattleEffect(
                    new AfterBattleDelayedTriggeredAbilityFactory(),
                    new UntapThisCreatureEffect()
                )));
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}