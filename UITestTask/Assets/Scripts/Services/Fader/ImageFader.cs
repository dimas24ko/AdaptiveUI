using System;
using DG.Tweening;
using UnityEngine.UI;

namespace UITestTask.Services.Fader
{
    public class ImageFader
    {
        private static ImageFader instance;

        public static ImageFader GetInstance()
        {
            if (instance == null)
            {
                instance = new ImageFader();
            }
            return instance;
        }
        
        public Action OnFadeInComplete;
        public Action OnFadeOutComplete;
        
        
        public void FadeIn(Image image, float duration, float endAlphaValue) => 
            image.DOFade(endAlphaValue, duration).OnComplete(()=> OnFadeInComplete?.Invoke());

        public void FadeOut(Image image, float duration, float endAlphaValue) => 
            image.DOFade(endAlphaValue, duration).OnComplete(()=> OnFadeOutComplete?.Invoke());
    }
}
