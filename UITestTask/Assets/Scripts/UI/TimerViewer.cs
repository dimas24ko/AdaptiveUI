using UITestTask.Runtime;
using UITestTask.Services.TimeFormatter;
using UITestTask.Services.Timer;

namespace UITestTask.UI
{
    public class TimerViewer : TextSetter
    {
        public LifeChargeTimer Timer;
        public LifesManager LifesManager;

        public string FullLifeText;

        private void Awake()
        {
            SubscribeOnTimer();
            
            LifesManager.OnLifesFull += ()=> SetTextValue(FullLifeText);
        }

        private void OnDestroy()
        {
            UnSubscribeOnTimer();
            
            LifesManager.OnLifesFull -= ()=> SetTextValue(FullLifeText);
        }
        
        private void ShowTime(int seconds)
        {
            if (LifesManager.IsFull)
                return;

            var timeValue = TimeFormatter.GetInstance().FromSecondsToMinuteAndSeconds(seconds);
            SetTextValue(timeValue);
        }

        private void SubscribeOnTimer() => 
            Timer.OnTimeChanged +=  ShowTime;
        
        private void UnSubscribeOnTimer() => 
            Timer.OnTimeChanged -= ShowTime;
    }
}
