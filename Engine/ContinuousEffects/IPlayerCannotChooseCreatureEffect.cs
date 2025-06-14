namespace Engine.ContinuousEffects
{
    public interface IPlayerCannotChooseCreatureEffect : IContinuousEffect
    {
        bool PlayerCannotChooseCreature(Card creature, System.Guid player, IGame game);
    }
}
