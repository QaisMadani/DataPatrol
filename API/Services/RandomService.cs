using API.Interfaces;

namespace API.Services
{
    public class RandomService : IRandomService
    {
        private readonly Random _rng = new();
        public int Next(int min = 1, int max = 101)
            => _rng.Next(min, max);
    }
}
