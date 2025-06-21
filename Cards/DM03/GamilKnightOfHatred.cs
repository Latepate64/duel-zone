using OneShotEffects;
using TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.DM03
{
    class GamilKnightOfHatred : Creature
    {
        public GamilKnightOfHatred() : base("Gamil, Knight of Hatred", 6, 4000, Race.DemonCommand, Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new GamilKnightOfHatredEffect()));
        }
    }

    class GamilKnightOfHatredEffect : SalvageCivilizationCreatureEffect
    {
        public GamilKnightOfHatredEffect() : base(0, 1)
        {
        }

        public GamilKnightOfHatredEffect(GamilKnightOfHatredEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GamilKnightOfHatredEffect(this);
        }

        public override string ToString()
        {
            return "You may return a darkness creature from your graveyard to your hand.";
        }

        protected override IEnumerable<Card> GetSelectableCards(IGame game, IAbility source)
        {
            return Controller.Graveyard.GetCreatures(Civilization.Darkness);
        }
    }
}
