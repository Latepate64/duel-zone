using Engine.Abilities;

namespace Cards.StaticAbilities
{
    public class ChargerAbility : StaticAbility
    {
        public ChargerAbility() : base(new ContinuousEffects.ThisSpellHasChargerEffect())
        {
        }
    }

    
}
