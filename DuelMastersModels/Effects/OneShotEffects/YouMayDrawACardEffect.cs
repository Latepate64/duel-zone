using DuelMastersModels.Choices;

namespace DuelMastersModels.Effects.OneShotEffects
{
    internal class YouMayDrawACardEffect : OneShotEffect
    {
        internal override Choice Apply(Duel duel, Player player, Choice choice)
        {
            if (choice == null) { return new YesNoChoice(player); }
            if ((choice as YesNoChoice).Decision) { player.DrawCards(1); }
            return null;
        }
    }
}
