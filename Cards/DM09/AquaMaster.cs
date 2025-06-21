using TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM09
{
    class AquaMaster : Creature
    {
        public AquaMaster() : base("Aqua Master", 6, 4000, Race.LiquidPeople, Civilization.Water)
        {
            AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(new AquaMasterEffect()));
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
            var shield = Controller.ChooseCard(GetOpponent(game).ShieldZone.Cards, ToString());
            shield?.TurnFaceUp();
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
