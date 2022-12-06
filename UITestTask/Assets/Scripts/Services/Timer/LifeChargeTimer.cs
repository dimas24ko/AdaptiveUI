using System;
using DG.Tweening;
using UnityEngine;

namespace UITestTask.Services.Timer
{
    public class LifeChargeTimer : MonoBehaviour, ITimerService
    {
        public int SecondsToRechargeLife;

        private int currentSeconds;

        private bool isExecuting;

        private Sequence timerSequence = null;

        public Action<int> OnTimeChanged;
        public Action OnTimeEnd;

        public void StartTimer()
        {
            if (timerSequence != null)
            {
                Debug.LogWarning("Timer is Already Starting");
                return;
            }
            isExecuting = true;
            currentSeconds = SecondsToRechargeLife;
            
            ChangeTime();
        }

        public void StopTimer()
        {
            timerSequence?.Kill();
            timerSequence = null;
            currentSeconds = SecondsToRechargeLife;
        }

        public void ResumeTimer() =>
            isExecuting = true;

        public void PauseTimer() =>
            isExecuting = false;

        public void ResetTimer()
        {
            currentSeconds = SecondsToRechargeLife;
            ChangeTime();
        }

        private void ChangeTime()
        {
            if (!isExecuting)
                return;

            if (currentSeconds == 0)
            {
                OnTimeEnd?.Invoke();
                return;
            }

            timerSequence = DOTween.Sequence()
                .Append(DOVirtual.DelayedCall(1f, OnNewSecondLeft))
                .Play();
        }

        private void OnNewSecondLeft()
        {
            currentSeconds--;
            
            ChangeTime();
            
            OnTimeChanged?.Invoke(currentSeconds);
        }
    }
}