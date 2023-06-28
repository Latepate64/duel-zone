using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM06
{
    class QTronicHypermind : EvolutionCreature
    {
        public QTronicHypermind() : base("Q-tronic Hypermind", 8, 8000, Race.Survivor, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new QTronicHypermindEffect());
            AddDoubleBreakerAbility();
        }
    }

    class QTronicHypermindEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            Applier.DrawCardsOptionally(Ability, game.BattleZone.Creatures.Count(x => x.HasRace(Race.Survivor)));
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
