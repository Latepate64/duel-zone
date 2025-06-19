using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Effects.Continuous;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM06
{
    class QTronicHypermind : EvolutionCreature
    {
        public QTronicHypermind() : base("Q-tronic Hypermind", 8, 8000, Race.Survivor, Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new QTronicHypermindEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }

    class QTronicHypermindEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            Controller.DrawCardsOptionally(game, Ability, game.BattleZone.GetCreatures(Race.Survivor).Count());
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
