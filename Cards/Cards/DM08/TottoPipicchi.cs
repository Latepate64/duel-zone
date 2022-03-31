using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class TottoPipicchi : Creature
    {
        public TottoPipicchi() : base("Totto Pipicchi", 3, 1000, Subtype.FireBird, Civilization.Fire)
        {
            AddStaticAbilities(new TottoPipicchiEffect());
        }
    }

    class TottoPipicchiEffect : SpeedAttackerEffect
    {
        public TottoPipicchiEffect() : base(new BattleZoneDragonFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TottoPipicchiEffect();
        }

        public override string ToString()
        {
            return "Each creature in the battle zone that has Dragon in its race has \"speed attacker.\"";
        }
    }

    class BattleZoneDragonFilter : CardFilters.BattleZoneCreatureFilter
    {
        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.IsDragon;
        }

        public override CardFilter Copy()
        {
            return new BattleZoneDragonFilter();
        }

        public override string ToString()
        {
            return "Each creature in the battle zone that has Dragon in its race";
        }
    }
}
