using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Linq;

namespace Cards.Cards.DM10
{
    class MysticMagician : Creature
    {
        public MysticMagician() : base("Mystic Magician", 5, 3000, Race.Merfolk, Civilization.Water)
        {
            AddStaticAbilities(new MysticMagicianTappedEffect(), new MysticMagicianDestroyedEffect());
        }
    }

    class MysticMagicianTappedEffect : ReplacementEffect
    {
        public MysticMagicianTappedEffect()
        {
        }

        public MysticMagicianTappedEffect(MysticMagicianTappedEffect effect) : base(effect)
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.BattleZone,
                EntersTapped = true,
            };
        }

        public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is ICardMovedEvent e && e.Destination == ZoneType.BattleZone && game.GetCard(e.CardInSourceZone).Owner == Controller && game.GetCard(e.CardInSourceZone).GetAbilities<Engine.Abilities.SilentSkillAbility>().Any();
        }

        public override IContinuousEffect Copy()
        {
            return new MysticMagicianTappedEffect(this);
        }

        public override string ToString()
        {
            return "Your creatures that have \"silent skill\" are put into the battle zone tapped.";
        }
    }

    class MysticMagicianDestroyedEffect : WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect
    {
        public MysticMagicianDestroyedEffect()
        {
        }

        public MysticMagicianDestroyedEffect(WhenCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MysticMagicianDestroyedEffect(this);
        }

        public override string ToString()
        {
            return "Whenever one of your creatures that has \"silent skill\" would be destroyed, put it into your hand instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return card.Owner == Controller && card.GetAbilities<Engine.Abilities.SilentSkillAbility>().Any();
        }
    }
}
