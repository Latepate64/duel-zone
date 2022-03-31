using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class MishaChannelerOfSuns : Creature
    {
        public MishaChannelerOfSuns() : base("Misha, Channeler of Suns", 5, 5000, Subtype.MechaDelSol, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByDragonsEffect());
        }
    }

    class ThisCreatureCannotBeAttackedByDragonsEffect : CannotBeAttackedEffect
    {
        public ThisCreatureCannotBeAttackedByDragonsEffect() : base(new TargetFilter(), new DragonInBattleZoneFilter(), new Durations.Indefinite())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeAttackedByDragonsEffect();
        }

        public override string ToString()
        {
            return "This creature can't be attacked by any creature that has Dragon in its race.";
        }
    }

    class DragonInBattleZoneFilter : CardFilters.BattleZoneCreatureFilter
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
            return "any creature that has Dragon";
        }
    }
}
