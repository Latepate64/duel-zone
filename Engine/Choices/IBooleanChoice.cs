namespace Engine.Choices
{
    public interface IBooleanChoice : IChoice
    {
        bool? Choice { get; set; }
    }
}
