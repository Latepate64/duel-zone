using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM08
{
    class DracodanceTotem : Creature
    {
        public DracodanceTotem() : base("Dracodance Totem", 2, 1000, Race.MysteryTotem, Civilization.Nature)
        {
            AddStaticAbilities(new DracodanceTotemEffect());
        }
    }

    class DracodanceTotemEffect : ContinuousEffects.DestructionReplacementEffect
    {
        public DracodanceTotemEffect() : base() 
        {
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            game.AddReflexiveTriggeredAbility(new TriggeredAbilities.ReflexiveTriggeredAbility(new DracodanceTotemRecoveryEffect(), Source));
            return new CardMovedEvent(gameEvent as ICardMovedEvent)
            {
                Destination = ZoneType.Hand
            };
        }

        public override IContinuousEffect Copy()
        {
            return new DracodanceTotemEffect();
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, if you have a creature that has Dragon in its race in your mana zone, put this creature into your mana zone instead of destroying it. Then return a creature that has Dragon in its race from your mana zone to your hand.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game) && Controller.ManaZone.Creatures.Any(x => x.IsDragon);
        }
    }

    class DracodanceTotemRecoveryEffect : OneShotEffects.ManaRecoveryEffect
    {
        public DracodanceTotemRecoveryEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DracodanceTotemRecoveryEffect();
        }

        public override string ToString()
        {
            return "Return a creature that has Dragon in its race from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.ManaZone.Creatures.Where(x => x.IsDragon);
        }
    }
}
