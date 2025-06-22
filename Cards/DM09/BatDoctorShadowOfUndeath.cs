using TriggeredAbilities;
using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM09
{
    sealed class BatDoctorShadowOfUndeath : Creature
    {
        public BatDoctorShadowOfUndeath() : base("Bat Doctor, Shadow of Undeath", 3, 2000, Race.Ghost, Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new BatDoctorShadowOfUndeathEffect()));
        }
    }

    sealed class BatDoctorShadowOfUndeathEffect : SalvageEffect
    {
        public BatDoctorShadowOfUndeathEffect() : base(0, 1, true)
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

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.Graveyard.GetOtherCreatures(Ability.Source.Id);
        }
    }
}
