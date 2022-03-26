﻿using Common;
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
                        new GandarSeekerOfExplosionsUntapEffect()),
                        source.Source,
                        source.Owner,
                        new Durations.Indefinite(),
                        true));
            return null;
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
        public GandarSeekerOfExplosionsUntapEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Light))
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
    }
}
