using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

sealed class CuriousEye : Creature
{
    public CuriousEye() : base("Curious Eye", 3, 1000, Race.CyberVirus,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new LookEffect(0, 1)));
    }
}