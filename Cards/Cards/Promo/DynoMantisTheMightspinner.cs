using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.Promo
{
    class DynoMantisTheMightspinner : EvolutionCreature
    {
        public DynoMantisTheMightspinner() : base("Dyno Mantis, the Mightspinner", 5, 7000, Engine.Subtype.GiantInsect, Engine.Civilization.Nature)
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

        public int GetAmount(IGame game, Engine.ICard creature)
        {
            return creature.Owner == GetController(game).Id && !IsSourceOfAbility(creature, game) && creature.Power >= 5000 ? 1 : 0;
        }

        public override string ToString()
        {
            return "Each of your other creatures in the battle zone that has power 5000 or more breaks one more shield.";
        }
    }
}
