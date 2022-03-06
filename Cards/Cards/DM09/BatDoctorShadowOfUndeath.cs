using Common;

namespace Cards.Cards.DM09
{
    class BatDoctorShadowOfUndeath : Creature
    {
        public BatDoctorShadowOfUndeath() : base("Bat Doctor, Shadow of Undeath", 3, 2000, Subtype.Ghost, Civilization.Darkness)
        {
            Abilities.Add(new TriggeredAbilities.DestroyedAbility(new OneShotEffects.SalvageEffect(new CardFilters.AnotherGraveyardCardFilter(), 0, 1, true)));
        }
    }
}
