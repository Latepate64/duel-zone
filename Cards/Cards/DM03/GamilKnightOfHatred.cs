using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM03
{
    class GamilKnightOfHatred : Creature
    {
        public GamilKnightOfHatred() : base("Gamil, Knight of Hatred", 6, 4000, Race.DemonCommand, Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new GamilKnightOfHatredEffect());
        }
    }

    class GamilKnightOfHatredEffect : OneShotEffects.SalvageCivilizationCreatureEffect
    {
        public GamilKnightOfHatredEffect() : base(0, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new GamilKnightOfHatredEffect();
        }

        public override string ToString()
        {
            return "You may return a darkness creature from your graveyard to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).Graveyard.GetCreatures(Civilization.Darkness);
        }
    }
}
