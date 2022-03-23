using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM03
{
    class SniperMosquito : Creature
    {
        public SniperMosquito() : base("Sniper Mosquito", 1, 2000, Common.Subtype.GiantInsect, Common.Civilization.Nature)
        {
            AddAbilities(new AttackAbility(new ReturnCardFromYourManaZoneToYourHandEffect()));
        }
    }
}