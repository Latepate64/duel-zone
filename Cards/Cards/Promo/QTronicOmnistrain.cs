using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.Promo
{
    class QTronicOmnistrain : EvolutionCreature
    {
        public QTronicOmnistrain() : base("Q-tronic Omnistrain", 6, 3000, Race.Survivor, Civilization.Nature)
        {
            AddShieldTrigger();
            AddStaticAbilities(new QTronicOmnistrainEffect());
        }
    }

    class QTronicOmnistrainEffect : ContinuousEffects.ContinuousEffect, IRaceAddingEffect
    {
        public void AddRace()
        {
            Game.BattleZone.GetCreatures(Applier).ToList().ForEach(x => x.AddGrantedRace(Race.Survivor));
        }

        public override IContinuousEffect Copy()
        {
            return new QTronicOmnistrainEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone is a Survivor in addition to its other races.";
        }
    }
}
