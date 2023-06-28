using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM09
{
    class AzaghastTyrantOfShadows : EvolutionCreature
    {
        public AzaghastTyrantOfShadows() : base("Azaghast, Tyrant of Shadows", 7, 9000, Race.DarkLord, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutRaceCreatureIntoTheBattleZoneAbility(Race.Ghost, new YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect()));
            AddDoubleBreakerAbility();
        }
    }

    class YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect : OneShotEffects.DestroyEffect
    {
        public YouMayDestroyOneOfYourOpponentsUntappedCreaturesEffect() : base(0, 1, true)
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

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetChoosableUntappedCreaturesControlledByChoosersOpponent(Applier);
        }
    }
}
