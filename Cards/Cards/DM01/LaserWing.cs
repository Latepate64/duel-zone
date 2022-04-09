using Cards.CardFilters;
using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM01
{
    class LaserWing : Spell
    {
        public LaserWing() : base("Laser Wing", 5, Common.Civilization.Light)
        {
            AddSpellAbilities(new LaserWingEffect());
        }
    }

    class LaserWingEffect : CreateContinuousEffectChoiceEffect
    {
        public LaserWingEffect() : base(0, 2, true, new ThisCreatureCannotBeBlockedThisTurnEffect())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new LaserWingEffect();
        }

        public override string ToString()
        {
            return "Choose up to 2 of your creatures in the battle zone. They can't be blocked this turn.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }
}
