using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM07
{
    class GandarSeekerOfExplosions : Creature
    {
        public GandarSeekerOfExplosions() : base("Gandar, Seeker of Explosions", 7, 6500, Race.MechaThunder, Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddTapAbility(new GandarSeekerOfExplosionsEffect());
        }
    }

    class GandarSeekerOfExplosionsEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(
                new DelayedTriggeredAbility(
                    new TriggeredAbilities.AtTheEndOfYourTurnAbility(
                        new GandarSeekerOfExplosionsUntapEffect()),
                        Source,
                        Applier,
                        true));
        }

        public override IOneShotEffect Copy()
        {
            return new GandarSeekerOfExplosionsEffect();
        }

        public override string ToString()
        {
            return "At the end of the turn, untap all your light creatures.";
        }
    }

    class GandarSeekerOfExplosionsUntapEffect : OneShotEffects.UntapAreaOfEffect
    {
        public GandarSeekerOfExplosionsUntapEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GandarSeekerOfExplosionsUntapEffect();
        }

        public override string ToString()
        {
            return "Untap all your light creatures.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Applier, Civilization.Light);
        }
    }
}
