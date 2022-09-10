namespace Eventyr.EndlessRunner.Scripts.Interfaces
{
    public interface IScoringService
    {
        public int Score { get; }
        public void Init();
        public void AddScore();
    }
}
