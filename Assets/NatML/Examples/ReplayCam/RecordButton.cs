/* 
*   NatCorder
*   Copyright (c) 2022 NatML Inc. All Rights Reserved.
*/

namespace NatSuite.Examples.Components {

	using System.Collections;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.Events;
	using UnityEngine.EventSystems;

    [RequireComponent(typeof(Image))]
    public class RecordButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

        [Header(@"Settings"), Range(5f, 6000000f), Tooltip(@"Maximum duration that button can be pressed.")]
        public float maxDuration = 10f;

        [Header(@"UI")]
        public Image countdown;

        [Header(@"Events")]
        public UnityEvent onTouchDown;
        public UnityEvent onTouchUp;


       // public GameObject VideoplayerPanel;
        private bool VideoPlayer;
        public Text Timer_txt;
        public GameObject timer;
        public GameObject VideostartSquareBtn;
        public GameObject VideoCloseeRoundBtn;

        private Image button;
        private bool touch;

        private void Awake () => button = GetComponent<Image>();

        private void Start () => Reset();

        private void Reset () {
            button.fillAmount = 1.0f;
            countdown.fillAmount = 0.0f;
        }

        void IPointerDownHandler.OnPointerDown (PointerEventData eventData) => StartCoroutine(Countdown());

        void IPointerUpHandler.OnPointerUp (PointerEventData eventData) => touch = false;

        private IEnumerator Countdown () {
            touch = true;
            // Wait for false touch
            yield return new WaitForSeconds(0.2f);
            if (!touch)
                yield break;
            // Start recording
            onTouchDown?.Invoke();
            // Animate the countdown
            var startTime = Time.time;
            while (touch) {
                var ratio = (Time.time - startTime) / maxDuration;
                touch = ratio <= 1f;
                countdown.fillAmount = ratio;
                button.fillAmount = 1f - ratio;
                yield return null;
            }
            Reset();
            onTouchUp?.Invoke();
        }



        public void StartAndStopVideo()
        {
            if (VideoPlayer == true)
            {
                if (timer.active == true)
                {
                    timer.SetActive(false);
                }
                VideostartSquareBtn.SetActive(false);
                VideoCloseeRoundBtn.SetActive(true);
                GameObject.Find("ReplayCam").GetComponent<ReplayCam>().StopRecording();
               // VideoplayerPanel.SetActive(true);
                VideoPlayer = false;

            }
            else
            {
                VideoPlayer = true;
                StartCoroutine(TimerCountdown());
            }
        }

        IEnumerator TimerCountdown()
        {
            timer.SetActive(true);
            Timer_txt.text = "3";
            yield return new WaitForSeconds(1f);
            Timer_txt.text = "2";
            yield return new WaitForSeconds(1f);
            Timer_txt.text = "1";
            yield return new WaitForSeconds(1f);
            timer.SetActive(false);
            StartRecordingVideo();
        }

        private void StartRecordingVideo()
        {
            VideostartSquareBtn.SetActive(true);
            VideoCloseeRoundBtn.SetActive(false);
            GameObject.Find("ReplayCam").GetComponent<ReplayCam>().StartRecording();
            StartCoroutine(Countdown());
        }
    }

}