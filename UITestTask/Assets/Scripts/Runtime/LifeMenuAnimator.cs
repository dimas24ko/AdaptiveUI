using DG.Tweening;
using UITestTask.Services.Fader;
using UnityEngine;
using UnityEngine.UI;

namespace UITestTask.Runtime
{
    public class LifeMenuAnimator : MonoBehaviour
    {
        public Image FadeImage;

        public Transform ViewWindow;

        public float StartXPosition;
        public float EndXPosition;
        public float MoveTime;
        
        public float FadeTime;
        public float MinAlphaValue;
        public float MaxAlphaValue;
        
        public void OpenAnimation()
        {
            FadeImage.gameObject.SetActive(true);
            ImageFader.GetInstance().FadeIn(FadeImage, FadeTime, MaxAlphaValue);
            ViewWindow.DOLocalMoveX(EndXPosition, MoveTime);
        }

        public void CloseAnimation()
        {
            ImageFader.GetInstance().FadeIn(FadeImage, FadeTime, MinAlphaValue);
            ViewWindow.DOLocalMoveX(StartXPosition, MoveTime);

            DOTween.Sequence()
                .Append(DOVirtual.DelayedCall(MoveTime, () => FadeImage.gameObject.SetActive(false)))
                .Play();
        }
    }
}