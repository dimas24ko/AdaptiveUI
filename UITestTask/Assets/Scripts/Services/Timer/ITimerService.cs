namespace UITestTask.Services.Timer
{
    public interface ITimerService
    {
        void StartTimer();
        void StopTimer();
        void PauseTimer();
        void ResetTimer();
        void ResumeTimer();

    }
}