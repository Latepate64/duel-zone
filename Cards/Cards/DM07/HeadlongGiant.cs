using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class HeadlongGiant : Creature
    {
        public HeadlongGiant() : base("Headlong Giant", 9, 14000, Race.Giant, Civilization.Nature)
        {
            AddStaticAbilities(new HeadlongGiantEffect(), new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(4000));
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.DiscardCardFromYourHandEffect());
            AddTripleBreakerAbility();
        }
    }

    class HeadlongGiantEffect : ContinuousEffect, ICannotAttackEffect
    {
        public HeadlongGiantEffect()
        {
        }

        public HeadlongGiantEffect(HeadlongGiantEffect effect) : base(effect)
        {
        }

        public bool CannotAttack(ICard attacker, IGame game)
        {
            return IsSourceOfAbility(attacker) && !Applier.Hand.HasCards;
        }

        public override IContinuousEffect Copy()
        {
            return new HeadlongGiantEffect(this);
        }

        public override string ToString()
        {
            return "This creature can't attack if you have no cards in your hand.";
        }
    }
}
