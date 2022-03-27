using Cards.CardFilters;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class PoisonWorm : Creature
    {
        public PoisonWorm() : base("Poison Worm", 4, 4000, Common.Subtype.ParasiteWorm, Common.Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PoisonWormEffect()));
        }
    }

    class PoisonWormEffect : OneShotEffects.DestroyEffect
    {
        public PoisonWormEffect() : base(new OwnersBattleZoneMaxPowerCreatureFilter(3000), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new PoisonWormEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your creatures that has power 3000 or less.";
        }
    }
}
