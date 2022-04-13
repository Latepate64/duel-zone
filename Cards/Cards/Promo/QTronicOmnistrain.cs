using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.Promo
{
    class QTronicOmnistrain : EvolutionCreature
    {
        public QTronicOmnistrain() : base("Q-tronic Omnistrain", 6, 3000, Subtype.Survivor, Civilization.Nature)
        {
            AddShieldTrigger();
            AddStaticAbilities(new QTronicOmnistrainEffect());
        }
    }

    class QTronicOmnistrainEffect : ContinuousEffects.ContinuousEffect, ISubtypeAddingEffect
    {
        public void AddSubtype(IGame game)
        {
            game.BattleZone.GetCreatures(GetController(game).Id).ToList().ForEach(x => x.AddGrantedSubtype(Subtype.Survivor));
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
