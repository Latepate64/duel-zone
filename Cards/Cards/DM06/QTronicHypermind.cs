using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM06
{
    class QTronicHypermind : EvolutionCreature
    {
        public QTronicHypermind() : base("Q-tronic Hypermind", 8, 8000, Subtype.Survivor, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new QTronicHypermindEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class QTronicHypermindEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            return new OneShotEffects.YouMayDrawCardsEffect(game.BattleZone.Creatures.Count(x => x.Subtypes.Contains(Subtype.Survivor)));
        }

        public override IOneShotEffect Copy()
        {
            return new QTronicHypermindEffect();
        }

        public override string ToString()
        {
            return "You may draw a card for each Survivor in the battle zone.";
        }
    }
}
