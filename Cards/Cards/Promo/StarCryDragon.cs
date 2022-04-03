using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.Promo
{
    class StarCryDragon : Creature
    {
        public StarCryDragon() : base("Star-Cry Dragon", 7, 8000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new StarCryDragonEffect());
            AddDoubleBreakerAbility();
        }
    }

    class StarCryDragonEffect : PowerModifyingEffect
    {
        public StarCryDragonEffect() : base(3000, new CardFilters.OwnersBattleZoneSubtypeCreatureExceptFilter(Subtype.ArmoredDragon), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new StarCryDragonEffect();
        }

        public override string ToString()
        {
            return "Each of your other Armored Dragons in the battle zone gets +3000 power.";
        }
    }
}
