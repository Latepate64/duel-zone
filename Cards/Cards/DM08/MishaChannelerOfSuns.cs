using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class MishaChannelerOfSuns : Creature
    {
        public MishaChannelerOfSuns() : base("Misha, Channeler of Suns", 5, 5000, Race.MechaDelSol, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByDragonsEffect());
        }
    }

    class ThisCreatureCannotBeAttackedByDragonsEffect : ContinuousEffect, ICannotBeAttackedEffect
    {
        public ThisCreatureCannotBeAttackedByDragonsEffect() : base()
        {
        }

        public bool Applies(ICard attacker, ICard targetOfAttack)
        {
            return IsSourceOfAbility(targetOfAttack) && attacker.IsDragon;
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
