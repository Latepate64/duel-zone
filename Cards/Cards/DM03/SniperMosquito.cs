using OneShotEffects;
using TriggeredAbilities;

namespace Cards.Cards.DM03
{
    class SniperMosquito : Engine.Creature
    {
        public SniperMosquito() : base("Sniper Mosquito", 1, 2000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new ReturnCardFromYourManaZoneToYourHandEffect()));
        }
    }
}