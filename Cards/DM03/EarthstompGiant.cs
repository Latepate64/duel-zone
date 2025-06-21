using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM03
{
    class EarthstompGiant : Creature
    {
        public EarthstompGiant() : base("Earthstomp Giant", 5, 8000, Race.Giant, Civilization.Nature)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new EarthstompGiantEffect()));
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

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return Controller.ManaZone.Creatures;
        }
    }
}
