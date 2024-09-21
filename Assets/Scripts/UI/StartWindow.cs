using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CookingPrototype.Controllers;
using UnityEngine.UI;
using System;

namespace CookingPrototype.UI
{
    public class StartWindow : MonoBehaviour
    {
        public TMP_Text GoalText = null;
        public Button StartButton = null;

        bool _isInit = false;


        void Start()
        {
            Show();
        }


        void Init()
        {
            StartButton.onClick.AddListener(StartGame);
        }

        public void Show()
        {
            if (!_isInit)
            {
                Init();
            }

            var gc = GameplayController.Instance;
            gc.TotalOrdersServedChanged += SetGoalText;

            //Set text in case total orders served already finished changing
            GoalText.text = $"{gc.OrdersTarget}";

            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void Hide()
        {
            var gc = GameplayController.Instance;
            gc.TotalOrdersServedChanged -= SetGoalText;

            gameObject.SetActive(false);
        }



        private void StartGame()
        {
            var gc = GameplayController.Instance;
            gc.Restart();

            Hide();
        }

        private void SetGoalText()
        {
            var gc = GameplayController.Instance;

            GoalText.text = $"{gc.OrdersTarget}";
        }
    }
}