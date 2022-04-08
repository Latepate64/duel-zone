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
        public StarCryDragonEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new StarCryDragonEffect();
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.GetCreatures(GetSourceAbility(game).Controller).Where(x => !IsSourceOfAbility(x, game) && x.HasSubtype(Subtype.ArmoredDragon)).ToList().ForEach(x => x.Power += 3000);
        }

        public override string ToString()
        {
            return "Each of your other Armored Dragons in the battle zone gets +3000 power.";
        }
    }
}
