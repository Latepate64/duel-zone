using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.Cards.DM12
{
    class NemonexBajulasRobomantis : EvolutionCreature
    {
        public NemonexBajulasRobomantis() : base("Nemonex, Bajula's Robomantis", 6, 5000, Race.Xenoparts, Race.GiantInsect, Civilization.Fire, Civilization.Nature)
        {
            AddStaticAbilities(new EachOfYourOtherRacesGetsPowerEffect(Race.Xenoparts, Race.GiantInsect));
            AddTriggeredAbility(new NemonexAbility());
        }
    }

    class NemonexAbility : TriggeredAbility
    {
        public NemonexAbility() : base(new OneShotEffects.YourOpponentChoosesCardInHisManaZoneAndPutsItIntoHisGraveyardEffect())
        {
        }

        public NemonexAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is BecomeUnblockedEvent e && e.Attacker.Owner == Controller && (e.Attacker.HasRace(Race.Xenoparts) || e.Attacker.HasRace(Race.GiantInsect));
        }

        public override IAbility Copy()
        {
            return new NemonexAbility(this);
        }

        public override string ToString()
        {
            return "Whenever any of your Xeno Parts or Giant Insects is attacking and isn't blocked, your opponent chooses a card in his mana zone, and puts it into his graveyard.";
        }
    }
}
