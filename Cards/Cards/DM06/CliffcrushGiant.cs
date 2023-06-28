using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM06
{
    class CliffcrushGiant : Creature
    {
        public CliffcrushGiant() : base("Cliffcrush Giant", 5, 7000, Race.Giant, Civilization.Nature)
        {
            AddStaticAbilities(new CliffcrushGiantEffect());
            AddDoubleBreakerAbility();
        }
    }

    class CliffcrushGiantEffect : ContinuousEffect, ICannotAttackEffect
    {
        public CliffcrushGiantEffect()
        {
        }

        public CliffcrushGiantEffect(CliffcrushGiantEffect effect) : base(effect)
        {
        }

        public bool CannotAttack(ICard creature, IGame game)
        {
            return IsSourceOfAbility(creature) && game.BattleZone.GetOtherUntappedCreatures(Applier, Source.Id).Any();
        }

        public override IContinuousEffect Copy()
        {
            return new CliffcrushGiantEffect(this);
        }

        public override string ToString()
        {
            return "While you have any other untapped creatures in the battle zone, this creature can't attack.";
        }
    }
}
