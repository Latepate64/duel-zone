using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

sealed class MigaloVizierOfSpycraft : TurboRushCreature
{
    public MigaloVizierOfSpycraft() : base("Migalo, Vizier of Spycraft", 2, 1500, Race.Initiate, Civilization.Light)
    {
        AddTurboRushAbility(new WheneverThisCreatureAttacksAbility(new MigaloVizierOfSpycraftEffect()));
    }
}
