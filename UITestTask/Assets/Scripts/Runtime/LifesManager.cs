using System;
using UITestTask.Services.Timer;
using UnityEngine;

namespace UITestTask.Runtime
{
    public class LifesManager : MonoBehaviour
    {
        public int MaxLifeCount;
        public int StartLifeCount;

        public LifeChargeTimer LifeTimer;

        public bool IsFull;

        private int lifesCounter;

        public int LifesCounter => lifesCounter;

        public Action OnLifesFull;
        public Action<int> OnOneLifeRecharged;
        public Action<int> OnOneLifeSpend;
        public Action OnLifesEmpty;

        private void Awake() =>
            SubscribeOnDependencies();

        private void Start()
        {
            lifesCounter = StartLifeCount;

            OnOneLifeRecharged?.Invoke(lifesCounter);

            if (lifesCounter < MaxLifeCount)
                LifeTimer.StartTimer();
        }

        private void OnDestroy() =>
            UnSubscribeOnDependencies();

        public void IncreaseLife()
        {
            if (lifesCounter >= MaxLifeCount)
                return;

            lifesCounter++;

            if (lifesCounter == MaxLifeCount)
            {
                IsFull = true;
                OnLifesFull?.Invoke();
            }
            else
                OnOneLifeRecharged?.Invoke(lifesCounter);
        }

        public void DecreaseLife()
        {
            if (lifesCounter <= 0)
                return;

            lifesCounter--;

            if (lifesCounter == 0)
                OnLifesEmpty?.Invoke();
            else
                OnOneLifeSpend?.Invoke(lifesCounter);

            IsFull = false;
        }

        public void FullAllLives()
        {
            lifesCounter = MaxLifeCount;
            IsFull = true;
            OnLifesFull?.Invoke();
        }

        private void SubscribeOnDependencies()
        {
            LifeTimer.OnTimeEnd += IncreaseLife;

            OnLifesFull += LifeTimer.StopTimer;
            OnLifesEmpty += LifeTimer.StartTimer;

            OnOneLifeSpend += _ =>
            {
                if (!IsFull) 
                    return;
                
                LifeTimer.ResetTimer();
                LifeTimer.StartTimer();
            };
            OnOneLifeRecharged += i => LifeTimer.ResetTimer();
        }

        private void UnSubscribeOnDependencies()
        {
            LifeTimer.OnTimeEnd -= IncreaseLife;

            OnLifesFull -= LifeTimer.StopTimer;
            OnLifesEmpty -= LifeTimer.StartTimer;
            OnOneLifeRecharged -= i => LifeTimer.ResetTimer();
        }
    }
}