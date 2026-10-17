using Abilities.Static;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM09;

public sealed class MagmadragonOgristVhal : Creature
{
    public MagmadragonOgristVhal(
        ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffectFactory factory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory,
        TripleBreakerAbilityFactory tripleBreakerAbilityFactory
    ) : base("Magmadragon Ogrist Vhal", 7, 3000, Race.VolcanoDragon,
        Civilization.Fire)
    {
        AddStaticAbilities(
            new MagmadragonOgristVhalEffect(),
            factory.Create(
                6000,
                doubleBreakerAbilityFactory.Create(),
                15000,
                tripleBreakerAbilityFactory.Create()));
    }
}
