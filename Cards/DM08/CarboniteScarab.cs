using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class CarboniteScarab : TurboRushCreature
{
    public CarboniteScarab() : base("Carbonite Scarab", 4, 3000,
        Race.GiantInsect, Civilization.Nature)
    {
        AddTurboRushAbility(
            new WheneverThisCreatureBecomesBlockedAbility(
                new ThisCreatureBreaksOpponentsShieldsEffect(1)));
    }
}