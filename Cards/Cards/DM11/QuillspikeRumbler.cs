using Cards.TriggeredAbilities;
using Engine;
using Engine.GameEvents;

namespace Cards.Cards.DM11
{
    class QuillspikeRumbler : Creature
    {
        public QuillspikeRumbler() : base("Quillspike Rumbler", 4, 3000, Race.BeastFolk, Civilization.Nature)
        {
            AddTriggeredAbility(new QuillspikeRumblerAbility());
        }
    }

    class QuillspikeRumblerAbility : WheneverThisCreatureAttacksAbility
    {
        public QuillspikeRumblerAbility() : base(new OneShotEffects.ThisCreatureGetsPowerUntilTheEndOfTheTurnEffect(3000))
        {
        }

        public QuillspikeRumblerAbility(WheneverThisCreatureAttacksAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent e && e.Target is ICard c;
        }

        public override string ToString()
        {
            return "Whenever this creature attacks a creature, this creature gets +3000 power until the end of the turn.";
        }
    }
}
