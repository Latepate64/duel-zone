using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.Cards.DM12
{
    class AgiraTheWarlordCrawler : EvolutionCreature
    {
        public AgiraTheWarlordCrawler() : base("Agira, the Warlord Crawler", 4, 5500, Race.Gladiator, Race.EarthEater, Civilization.Light, Civilization.Water)
        {
            AddStaticAbilities(new EachOfYourOtherRacesGetsPowerEffect(Race.Gladiator, Race.EarthEater));
            AddTriggeredAbility(new AgiraAbility());
        }
    }

    class AgiraAbility : TriggeredAbility
    {
        public AgiraAbility() : base(new OneShotEffects.YouMayDrawCardEffect())
        {
        }

        public AgiraAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is BecomeBlockedEvent e && e.Blocker.Owner == Controller && (e.Blocker.HasRace(Race.Gladiator) || e.Blocker.HasRace(Race.EarthEater));
        }

        public override IAbility Copy()
        {
            return new AgiraAbility(this);
        }

        public override string ToString()
        {
            return "Whenever one of your Gladiators or Earth Eaters blocks, you may draw a card.";
        }
    }
}
