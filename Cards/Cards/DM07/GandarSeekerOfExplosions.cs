using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class GandarSeekerOfExplosions : Creature
    {
        public GandarSeekerOfExplosions() : base("Gandar, Seeker of Explosions", 7, 6500, Subtype.MechaThunder, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility(), new TapAbility(new GandarSeekerOfExplosionsEffect()));
        }
    }

    class GandarSeekerOfExplosionsEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            game.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(
                new TriggeredAbilities.AtTheEndOfYourTurnAbility(
                    new OneShotEffects.UntapEffect(new CardFilters.OwnersBattleZoneCreatureFilter(Civilization.Light))),
                    new Engine.Durations.Once(),
                    source.Id,
                    source.Owner));
        }

        public override OneShotEffect Copy()
        {
            return new GandarSeekerOfExplosionsEffect();
        }

        public override string ToString()
        {
            return "At the end of the turn, untap all your light creatures.";
        }
    }
}
