using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class MishaChannelerOfSuns : Creature
    {
        public MishaChannelerOfSuns() : base("Misha, Channeler of Suns", 5, 5000, Subtype.MechaDelSol, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByDragonsEffect());
        }
    }

    class ThisCreatureCannotBeAttackedByDragonsEffect : ContinuousEffect, ICannotBeAttackedEffect
    {
        public ThisCreatureCannotBeAttackedByDragonsEffect() : base(new TargetFilter())
        {
        }

        public bool Applies(Engine.ICard attacker)
        {
            return attacker.IsDragon;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeAttackedByDragonsEffect();
        }

        public override string ToString()
        {
            return "This creature can't be attacked by any creature that has Dragon in its race.";
        }
    }
}
