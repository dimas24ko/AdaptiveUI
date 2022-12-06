using System;
using UnityEngine;

namespace UITestTask.Runtime
{
    public class ReconstructionLifeMenuOnState : MonoBehaviour
    {
        public LifesManager LifesManager;
        
        public GameObject TimerText;
        public GameObject UseLifeButton;
        public GameObject RefillLivesButton;
        public GameObject Heart;


        public UIElementSettings RefillUsual;
        public UIElementSettings RefillEmptyLifes;

        public UIElementSettings UseLifeUsual;
        public UIElementSettings UseLifeFullLifes;

        public UIElementSettings HeartUsual;
        public UIElementSettings HeartEmptyLifes;
        public UIElementSettings HeartFullLifes;


        private void Awake()
        {
            SetupUsualSettings();

            LifesManager.OnLifesFull += ConstructFullLifesView;
            LifesManager.OnLifesEmpty += ConstructEmptyLifesView;
            LifesManager.OnOneLifeSpend += (_)=> ConstructUsualView();
        }

        private void ConstructUsualView()
        {
            TimerText.SetActive(true);
            UseLifeButton.SetActive(true);
            RefillLivesButton.SetActive(true);

            SetupElement(Heart, HeartUsual);
            SetupElement(UseLifeButton, UseLifeUsual);
            SetupElement(RefillLivesButton, RefillUsual);

        }

        private void ConstructEmptyLifesView()
        {
            UseLifeButton.SetActive(false);
            TimerText.SetActive(true);
            RefillLivesButton.SetActive(true);
            
            SetupElement(Heart, HeartEmptyLifes);
            SetupElement(RefillLivesButton, RefillEmptyLifes);
        }

        private void ConstructFullLifesView()
        {
            TimerText.SetActive(false);
            RefillLivesButton.SetActive(false);
            UseLifeButton.SetActive(true);
            
            SetupElement(Heart, HeartFullLifes);
            SetupElement(UseLifeButton, UseLifeFullLifes);
        }

        private void SetupElement(GameObject element, UIElementSettings settings)
        {
            element.transform.localPosition = settings.Position;
            element.transform.localScale = settings.Scale;
        }
        
        private void SetupUsualSettings()
        {
            UseLifeUsual.Position = UseLifeButton.transform.localPosition;
            RefillUsual.Position = RefillLivesButton.transform.localPosition;
            HeartUsual.Position = Heart.transform.localPosition;

            UseLifeUsual.Scale = UseLifeButton.transform.localScale;
            RefillUsual.Scale = RefillLivesButton.transform.localScale;
            HeartUsual.Scale = Heart.transform.localScale;
        }
    }

    [Serializable]
    public class UIElementSettings
    {
        public Vector3 Scale;
        public Vector3 Position;
    }
}