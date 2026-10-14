using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM04;

sealed class AstralWarper : EvolutionCreature
{
    public AstralWarper() : base("Astral Warper", 6, 5000, Race.CyberVirus,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new YouMayDrawCardsEffect(3)));
    }
}