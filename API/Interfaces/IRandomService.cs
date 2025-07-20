namespace API.Interfaces
{
    public interface IRandomService
    {
        int Next(int min = 1, int max = 101);
    }
}
