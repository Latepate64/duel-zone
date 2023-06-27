using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM03
{
    class EarthstompGiant : Creature
    {
        public EarthstompGiant() : base("Earthstomp Giant", 5, 8000, Race.Giant, Civilization.Nature)
        {
            AddDoubleBreakerAbility();
            AddWheneverThisCreatureAttacksAbility(new EarthstompGiantEffect());
        }
    }

    class EarthstompGiantEffect : OneShotEffects.ManaRecoveryAreaOfEffect
    {
        public EarthstompGiantEffect() : base()
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return Applier.ManaZone.Creatures;
        }
    }
}
