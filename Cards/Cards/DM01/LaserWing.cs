using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM01
{
    class LaserWing : Spell
    {
        public LaserWing() : base("Laser Wing", 5, Civilization.Light)
        {
            AddSpellAbilities(new LaserWingEffect());
        }
    }

    class LaserWingEffect : CardSelectionEffect
    {
        public LaserWingEffect() : base(0, 2, true)
        {
        }

        public LaserWingEffect(LaserWingEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new LaserWingEffect(this);
        }

        public override string ToString()
        {
            return "Choose up to 2 of your creatures in the battle zone. They can't be blocked this turn.";
        }

        protected override void Apply(IAbility source, params ICard[] cards)
        {
            Game.AddContinuousEffects(Ability, new ChosenCreaturesCannotBeBlockedThisTurnEffect(cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IAbility source)
        {
            return Game.BattleZone.GetCreatures(Applier);
        }
    }
}
