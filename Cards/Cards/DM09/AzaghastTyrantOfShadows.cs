using Common;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class AzaghastTyrantOfShadows : EvolutionCreature
    {
        public AzaghastTyrantOfShadows() : base("Azaghast, Tyrant of Shadows", 7, 9000, Subtype.DarkLord, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutSubtypeCreatureIntoTheBattleZoneAbility(Subtype.Ghost, new YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect()));
            AddDoubleBreakerAbility();
        }
    }

    class YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect : OneShotEffects.DestroyEffect
    {
        public YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect() : base(new CardFilters.OpponentsBattleZoneChoosableUntappedCreatureFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect();
        }

        public override string ToString()
        {
            return "You may destroy one of your opponent's untapped creatures.";
        }
    }
}
