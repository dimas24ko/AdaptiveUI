using UITestTask.Runtime;

namespace UITestTask.UI.View
{
    public class LifesMenu : View
    {
        public LifeMenuAnimator Animator;
        
        private void Awake()
        {
            OnOpen += (_)=> Animator.OpenAnimation();
            OnClose += (_)=> Animator.CloseAnimation();
        }
        
        public override void Open()
        {
            ViewGameObject.SetActive(true);
            OnOpen?.Invoke(Type);
        }
        
        public override void Close() => 
            OnClose?.Invoke(Type);
    }
}