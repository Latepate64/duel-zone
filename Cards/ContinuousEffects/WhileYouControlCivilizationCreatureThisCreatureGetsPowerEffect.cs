using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable, ICivilizationable
    {
        public int Power { get; }
        public Civilization Civilization { get; }

        public WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(int power, Civilization civilization) : base()
        {
            Civilization = civilization;
            Power = power;
        }

        public WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect effect) : base(effect)
        {
            Civilization = effect.Civilization;
            Power = effect.Power;
        }

        public override ContinuousEffect Copy()
        {
            return new WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(this);
        }

        public override string ToString()
        {
            return $"While you have a {Civilization} creature in the battle zone, this creature gets +{Power} power.";
        }

        public void ModifyPower(IGame game)
        {
            if (game.BattleZone.GetCreatures(Applier).Any(x => x.HasCivilization(Civilization)))
            {
                Source.Power += Power;
            }
        }
    }
}