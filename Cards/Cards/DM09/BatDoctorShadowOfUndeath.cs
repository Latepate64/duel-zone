using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM09
{
    class BatDoctorShadowOfUndeath : Creature
    {
        public BatDoctorShadowOfUndeath() : base("Bat Doctor, Shadow of Undeath", 3, 2000, Subtype.Ghost, Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new BatDoctorShadowOfUndeathEffect());
        }
    }

    class BatDoctorShadowOfUndeathEffect : OneShotEffects.SalvageEffect
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
            return game.GetPlayer(source.Controller).Graveyard.GetOtherCreatures(source.Source);
        }
    }
}
