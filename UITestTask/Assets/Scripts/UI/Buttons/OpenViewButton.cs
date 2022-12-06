using UnityEngine;

namespace UITestTask.UI.Buttons
{
    public class OpenViewButton : MonoBehaviour, IButton
    {
        public View.View View;

        public void OnClick() => 
            View.Open();
    }
}