using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

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

    class StarCryDragonEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public StarCryDragonEffect() : base(new CardFilters.OwnersBattleZoneSubtypeCreatureExceptFilter(Subtype.ArmoredDragon), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new StarCryDragonEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += 3000);
        }

        public override string ToString()
        {
            return "Each of your other Armored Dragons in the battle zone gets +3000 power.";
        }
    }
}
