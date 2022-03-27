using Common;

namespace Cards.StaticAbilities
{
    class EachCivilizationCardCostsMoreAbility : Engine.Abilities.StaticAbility
    {
        public EachCivilizationCardCostsMoreAbility(Civilization civilization, int increase) : base(new ContinuousEffects.EachCivilizationCardCostsMoreEffect(civilization, increase))
        {
        }
    }
}
