using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class CyclolinkSpectralKnight : Creature
{
    public CyclolinkSpectralKnight() : base("Cyclolink, Spectral Knight", 4,
        3000, Race.RainbowPhantom, Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new SpellFilter()
        )));
    }
}