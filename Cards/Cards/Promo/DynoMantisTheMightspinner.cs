using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.Promo
{
    class DynoMantisTheMightspinner : EvolutionCreature
    {
        public DynoMantisTheMightspinner() : base("Dyno Mantis, the Mightspinner", 5, 7000, Race.GiantInsect, Civilization.Nature)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new DynoMantisEffect());
        }
    }

    class DynoMantisEffect : ContinuousEffects.ContinuousEffect, IBreaksAdditionalShieldsEffect
    {
        public override IContinuousEffect Copy()
        {
            return new DynoMantisEffect();
        }

        public int GetAmount(IGame game, ICard creature)
        {
            return creature.Owner == Controller.Id && !IsSourceOfAbility(creature) && creature.Power >= 5000 ? 1 : 0;
        }

        public override string ToString()
        {
            return "Each of your other creatures in the battle zone that has power 5000 or more breaks one more shield.";
        }
    }
}
