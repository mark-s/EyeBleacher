namespace EyeBleacher.Interfaces
{
    public interface IUrlCollection
    {
        int Count { get; }

        string[] Urls { get; }
    }
}