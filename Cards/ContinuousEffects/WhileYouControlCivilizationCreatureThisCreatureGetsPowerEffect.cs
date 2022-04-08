using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly Civilization _civilization;
        private readonly int _power;

        public WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(Civilization civilization, int power) : base()
        {
            _civilization = civilization;
            _power = power;
        }

        public WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
            _power = effect._power;
        }

        public override ContinuousEffect Copy()
        {
            return new WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(this);
        }

        public override string ToString()
        {
            return $"While you have a {_civilization} creature in the battle zone, this creature gets +{_power} power.";
        }

        public void ModifyPower(IGame game)
        {
            if (game.BattleZone.GetCreatures(GetSourceAbility(game).Id).Any(x => x.HasCivilization(_civilization)))
            {
                GetSourceCard(game).Power += _power;
            }
        }
    }
}