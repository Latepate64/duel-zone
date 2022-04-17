using Cards.OneShotEffects;

namespace Cards.Cards.DM03
{
    class SniperMosquito : Creature
    {
        public SniperMosquito() : base("Sniper Mosquito", 1, 2000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddWheneverThisCreatureAttacksAbility(new ReturnCardFromYourManaZoneToYourHandEffect());
        }
    }
}