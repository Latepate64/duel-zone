using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM03
{
    sealed class SniperMosquito : Engine.Creature
    {
        public SniperMosquito() : base("Sniper Mosquito", 1, 2000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new ReturnCardFromYourManaZoneToYourHandEffect()));
        }
    }
}