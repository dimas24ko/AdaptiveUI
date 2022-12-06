using UnityEngine;

namespace UITestTask.UI.Buttons
{
    public class CloseViewButton : MonoBehaviour, IButton
    {
        public View.View View;

        public void OnClick() => 
            View.Close();
    }
}