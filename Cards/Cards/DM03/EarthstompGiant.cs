using Common;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class EarthstompGiant : Creature
    {
        public EarthstompGiant() : base("Earthstomp Giant", 5, 8000, Subtype.Giant, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility(), new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new EarthstompGiantEffect()));
        }
    }

    class EarthstompGiantEffect : OneShotEffects.ManaRecoveryAreaOfEffect
    {
        public EarthstompGiantEffect() : base(new CardFilters.OwnersManaZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new EarthstompGiantEffect();
        }

        public override string ToString()
        {
            return "Return all creatures from your mana zone to your hand.";
        }
    }
}
