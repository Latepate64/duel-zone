using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM10
{
    sealed class TajimalVizierOfAqua : Creature
    {
        public TajimalVizierOfAqua() : base("Tajimal, Vizier of Aqua", 3, 4000, [Race.Initiate, Race.LiquidPeople], Civilization.Light, Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddStaticAbilities(new TajimalEffect());
        }
    }

    sealed class TajimalEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public TajimalEffect()
        {
        }

        public TajimalEffect(TajimalEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TajimalEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            throw new System.NotImplementedException();
            // if (game.CurrentTurn.CurrentPhase is AttackPhase a)
            // {
            //     var against = a.GetCreatureBattlingAgainst(Source as Creature);
            //     if (against != null && against.HasCivilization(Civilization.Fire))
            //     {
            //         (Source as Creature).IncreasePower(4000);
            //     }
            // }
        }

        public override string ToString()
        {
            return "While battling a fire creature, this creature gets +4000 power.";
        }
    }
}
