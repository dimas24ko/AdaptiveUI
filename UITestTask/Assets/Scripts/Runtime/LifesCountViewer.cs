using UITestTask.UI;

namespace UITestTask.Runtime
{
    public class LifesCountViewer : TextSetter
    {
        public LifesManager LifesManager;
        
        private void Awake() => 
            SubscribeOnLifesManager();

        private void OnDestroy() => 
            UnSubscribeOnLifesManager();

        private void SubscribeOnLifesManager()
        {
            LifesManager.OnOneLifeRecharged += value => SetTextValue(value.ToString());
            LifesManager.OnOneLifeSpend += value => SetTextValue(value.ToString());
            
            LifesManager.OnLifesFull += () => SetTextValue(LifesManager.MaxLifeCount.ToString());
            LifesManager.OnLifesEmpty += () => SetTextValue(0.ToString());
        }
        
        private void UnSubscribeOnLifesManager()
        {
            LifesManager.OnOneLifeRecharged -= value => SetTextValue(value.ToString());
            LifesManager.OnOneLifeSpend -= value => SetTextValue(value.ToString());
            
            LifesManager.OnLifesFull -= () => SetTextValue(LifesManager.MaxLifeCount.ToString());
            LifesManager.OnLifesEmpty -= () => SetTextValue(0.ToString());
        }
    }
}