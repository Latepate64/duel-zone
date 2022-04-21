using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class AquaMaster : Creature
    {
        public AquaMaster() : base("Aqua Master", 6, 4000, Race.LiquidPeople, Civilization.Water)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new AquaMasterEffect()));
        }
    }

    class AquaMasterEffect : OneShotEffect
    {
        public AquaMasterEffect()
        {
        }

        public AquaMasterEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var shield = GetController(game).ChooseCard(GetOpponent(game).ShieldZone.Cards, ToString());
            if (shield != null)
            {
                shield.FaceDown = false;
            }
        }

        public override IOneShotEffect Copy()
        {
            return new AquaMasterEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's shields and turn it face up.";
        }
    }
}
