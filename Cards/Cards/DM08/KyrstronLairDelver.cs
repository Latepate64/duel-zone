using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    class KyrstronLairDelver : Creature
    {
        public KyrstronLairDelver() : base("Kyrstron, Lair Delver", 5, 1000, Subtype.Dragonoid, Civilization.Fire)
        {
            AddWhenThisCreatureIsDestroyedAbility(new KyrstronLairDelverEffect());
        }
    }

    class KyrstronLairDelverEffect : CardMovingChoiceEffect
    {
        public KyrstronLairDelverEffect() : base(new DragonInYourHandFilter(), 0, 1, true, ZoneType.Hand, ZoneType.BattleZone)
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
    }

    class DragonInYourHandFilter : CardFilters.OwnersHandCreatureFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.IsDragon;
        }

        public override CardFilter Copy()
        {
            return new DragonInYourHandFilter();
        }

        public override string ToString()
        {
            return "a creature that has Dragon in its race from your hand";
        }
    }
}
