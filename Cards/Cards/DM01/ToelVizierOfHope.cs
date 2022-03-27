using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class ToelVizierOfHope : Creature
    {
        public ToelVizierOfHope() : base("Toel, Vizier of Hope", 5, 2000, Common.Subtype.Initiate, Common.Civilization.Light)
        {
            AddAbilities(new AtTheEndOfYourTurnAbility(new ToelVizierOfHopeEffect()));
        }
    }

    class ToelVizierOfHopeEffect : ControllerMayUntapCreatureEffect
    {
        public ToelVizierOfHopeEffect() : base(new OwnersBattleZoneCreatureFilter())
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
    }
}
