using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class GamilKnightOfHatred : Creature
    {
        public GamilKnightOfHatred() : base("Gamil, Knight of Hatred", 6, 4000, Common.Subtype.DemonCommand, Common.Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new GamilKnightOfHatredEffect());
        }
    }

    class GamilKnightOfHatredEffect : OneShotEffects.SalvageCivilizationCreatureEffect
    {
        public GamilKnightOfHatredEffect() : base(0, 1, Common.Civilization.Darkness)
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
    }
}
