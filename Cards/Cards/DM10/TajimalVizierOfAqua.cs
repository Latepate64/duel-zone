using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.Steps;

namespace Cards.Cards.DM10
{
    class TajimalVizierOfAqua : Creature
    {
        public TajimalVizierOfAqua() : base("Tajimal, Vizier of Aqua", 3, 4000, Race.Initiate, Race.LiquidPeople, Civilization.Light, Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddStaticAbilities(new TajimalEffect());
        }
    }

    class TajimalEffect : ContinuousEffect, IPowerModifyingEffect
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
            if (game.CurrentTurn.CurrentPhase is AttackPhase a)
            {
                var against = a.GetCreatureBattlingAgainst(Source);
                if (against != null && against.HasCivilization(Civilization.Fire))
                {
                    Source.Power += 4000;
                }
            }
        }

        public override string ToString()
        {
            return "While battling a fire creature, this creature gets +4000 power.";
        }
    }
}
