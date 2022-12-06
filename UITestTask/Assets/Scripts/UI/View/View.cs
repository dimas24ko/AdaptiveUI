using System;
using UnityEngine;

namespace UITestTask.UI.View
{
    public class View : MonoBehaviour
    {
        public GameObject ViewGameObject;
        public ViewType Type;

        public Action<ViewType> OnOpen;
        public Action<ViewType> OnClose;

        public virtual void Open()
        {
            ViewGameObject.SetActive(true);
            OnOpen?.Invoke(Type);
        }
        
        public virtual void Close()
        {
            ViewGameObject.SetActive(false);
            OnClose?.Invoke(Type);
        }
    }
}