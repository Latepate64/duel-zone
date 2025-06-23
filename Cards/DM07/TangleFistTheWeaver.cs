using OneShotEffects;
using Engine.Abilities;
using Engine;
using Interfaces;

namespace Cards.DM07;

sealed class TangleFistTheWeaver : Creature
{
    public TangleFistTheWeaver() : base("Tangle Fist, the Weaver", 4, 2000, Race.BeastFolk, Civilization.Nature)
    {
        AddAbilities(new TapAbility(new YouMayPutUpToCardsFromYourHandIntoYourManaZoneEffect(3)));
    }
}