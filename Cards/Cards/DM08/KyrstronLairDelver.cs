using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM08
{
    class KyrstronLairDelver : Creature
    {
        public KyrstronLairDelver() : base("Kyrstron, Lair Delver", 5, 1000, Race.Dragonoid, Civilization.Fire)
        {
            AddWhenThisCreatureIsDestroyedAbility(new KyrstronLairDelverEffect());
        }
    }

    class KyrstronLairDelverEffect : CardMovingChoiceEffect
    {
        public KyrstronLairDelverEffect() : base(0, 1, true, ZoneType.Hand, ZoneType.BattleZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new KyrstronLairDelverEffect();
        }

        public override string ToString()
        {
            return "You may put a creature that has Dragon in its race from your hand into the battle zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.Hand.Cards.Where(x => x.IsDragon);
        }
    }
}
