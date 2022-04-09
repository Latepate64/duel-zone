using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM08
{
    class DracodanceTotem : Creature
    {
        public DracodanceTotem() : base("Dracodance Totem", 2, 1000, Subtype.MysteryTotem, Civilization.Nature)
        {
            AddStaticAbilities(new DracodanceTotemEffect());
        }
    }

    class DracodanceTotemEffect : ContinuousEffects.DestructionReplacementEffect
    {
        public DracodanceTotemEffect() : base() 
        {
        }

        public override bool Apply(IGame game, Engine.IPlayer player, Engine.ICard card)
        {
            var manaZoneDragons = player.ManaZone.Creatures.Where(x => x.IsDragon);
            if (manaZoneDragons.Any())
            {
                game.Move(ZoneType.BattleZone, ZoneType.ManaZone, card);
                new DracodanceTotemRecoveryEffect().Apply(game, null);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override IContinuousEffect Copy()
        {
            return new DracodanceTotemEffect();
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, if you have a creature that has Dragon in its race in your mana zone, put this creature into your mana zone instead of destroying it. Then return a creature that has Dragon in its race from your mana zone to your hand.";
        }

        protected override bool Applies(Engine.ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }
    }

    class DracodanceTotemRecoveryEffect : OneShotEffects.ManaRecoveryEffect
    {
        public DracodanceTotemRecoveryEffect() : base(1, 1, true, new CardFilters.DragonInYourManaZoneFilter())
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

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.GetPlayer(source.Controller).ManaZone.Creatures.Where(x => x.IsDragon);
        }
    }
}
