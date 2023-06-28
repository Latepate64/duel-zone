﻿using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    class Dracobarrier : Spell
    {
        public Dracobarrier() : base("Dracobarrier", 3, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new DracobarrierEffect());
        }
    }

    class DracobarrierEffect : OneShotEffect
    {
        public DracobarrierEffect()
        {
        }

        public DracobarrierEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var controller = Applier;
            var tapped = controller.ChooseOpponentsCreature(ToString());
            if (tapped != null)
            {
                controller.Tap(tapped);
                if (tapped.IsDragon)
                {
                    controller.PutFromTopOfDeckIntoShieldZone(1, Ability);
                }
            }
        }

        public override IOneShotEffect Copy()
        {
            return new DracobarrierEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and tap it. If it has Dragon in its race, add the top card of your deck to your shields face down.";
        }
    }
}
