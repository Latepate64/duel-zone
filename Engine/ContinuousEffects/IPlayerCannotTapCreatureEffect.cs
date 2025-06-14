namespace Engine.ContinuousEffects
{
    public interface IPlayerCannotTapCreatureEffect : IContinuousEffect
    {
        bool PlayerCannotTapCreature(Player player, Card creature, IGame game);
    }
}
