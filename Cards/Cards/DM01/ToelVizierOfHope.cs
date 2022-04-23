using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM01
{
    class ToelVizierOfHope : Creature
    {
        public ToelVizierOfHope() : base("Toel, Vizier of Hope", 5, 2000, Race.Initiate, Civilization.Light)
        {
            AddAtTheEndOfYourTurnAbility(new ToelVizierOfHopeEffect());
        }
    }

    class ToelVizierOfHopeEffect : ControllerMayUntapCreatureEffect
    {
        public ToelVizierOfHopeEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ToelVizierOfHopeEffect();
        }

        public override string ToString()
        {
            return "You may untap all your creatures in the battle zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetOtherCreatures(Ability.ControllerPlayer.Id);
        }
    }
}
