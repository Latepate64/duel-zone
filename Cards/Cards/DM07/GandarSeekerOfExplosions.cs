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
        public override object Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(
                new DelayedTriggeredAbility(
                    new TriggeredAbilities.AtTheEndOfYourTurnAbility(
                        new OneShotEffects.UntapAreaOfEffect(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Light))),
                        source.Source,
                        source.Owner));
            return null;
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
