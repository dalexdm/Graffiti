using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Lighthouse
{
    public class Switcheroo : MonoBehaviour
    {
        
        private bool gazing = false;
        Slider slider;

        void Start()
        {
            slider = GetComponent<Slider>();
        }

        void OnGazeEnter()
        {
            gazing = true;
        }

        void OnGazeLeave()
        {
            gazing = false;
        }

        void OnSelect()
        {
            if (slider.value == 0.0f) slider.value = 1.0f;
            else slider.value = 0.0f;
        }

        void Update()
        {

        }
    }
}