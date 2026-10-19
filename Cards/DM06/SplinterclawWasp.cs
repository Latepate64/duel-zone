using StaticAbilities;
using ContinuousEffects.PowerModifying;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class SplinterclawWasp : Creature
{
    public SplinterclawWasp() : base("Splinterclaw Wasp", 7, 4000,
        Race.GiantInsect, Civilization.Nature)
    {
        AddStaticAbilities(new PowerAttackerEffect(3000));
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(
            new WheneverThisCreatureBecomesBlockedAbility(
                new ThisCreatureBreaksOpponentsShieldsEffect(1)));
    }
}