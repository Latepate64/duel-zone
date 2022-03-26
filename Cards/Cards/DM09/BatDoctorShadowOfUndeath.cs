using Common;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class BatDoctorShadowOfUndeath : Creature
    {
        public BatDoctorShadowOfUndeath() : base("Bat Doctor, Shadow of Undeath", 3, 2000, Subtype.Ghost, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new BatDoctorShadowOfUndeathEffect()));
        }
    }

    class BatDoctorShadowOfUndeathEffect : OneShotEffects.SalvageEffect
    {
        public BatDoctorShadowOfUndeathEffect() : base(new CardFilters.AnotherGraveyardCardFilter(), 0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BatDoctorShadowOfUndeathEffect();
        }

        public override string ToString()
        {
            return "You may return another creature from your graveyard to your hand.";
        }
    }
}
