using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM08
{
    sealed class MishaChannelerOfSuns : Creature
    {
        public MishaChannelerOfSuns() : base("Misha, Channeler of Suns", 5, 5000, Race.MechaDelSol, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByDragonsEffect());
        }
    }

    sealed class ThisCreatureCannotBeAttackedByDragonsEffect : ContinuousEffect, ICannotBeAttackedEffect
    {
        public ThisCreatureCannotBeAttackedByDragonsEffect() : base()
        {
        }

        public bool Applies(ICreature attacker, ICreature targetOfAttack, IGame game)
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
