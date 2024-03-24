using System;
using System.Collections;
using UnityEngine;

namespace ServiceLocator.Wave.Bloon
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BloonView : MonoBehaviour
    {
        public BloonController Controller { get ; set ; }

        private SpriteRenderer spriteRenderer;
        private const float totalDuration = 3f;
        private Animator animator;
        public event Action OnRegeneratingHealth;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            CheckBloonTypeToStartTimer();
        }

        private void CheckBloonTypeToStartTimer()
        {
            bool isThisBloonBoss = Controller.IsBloonTypeBoss();
            if (isThisBloonBoss)
            {
                StartCoroutine(CheckTimer());
            }
        }

        private void Update()
        {
            Controller.FollowWayPoints();
        }

        IEnumerator CheckTimer()
        {
            float timeElapsed = 0f;
            while (true)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= totalDuration)
                {
                    // invoke event to regenerate health
                    OnRegeneratingHealth?.Invoke();
                    timeElapsed = 0;
                }
                yield return null;
            }
        }

        public void SetRenderer(Sprite spriteToSet)
        {
            spriteRenderer.sprite = spriteToSet;
        }

        public void SetSortingOrder(int sortingOrder) => spriteRenderer.sortingOrder = sortingOrder;

        public void PopBloon()
        {
            animator.enabled = true;
            animator.Play("Pop", 0);
        }

        public void PopAnimationPlayed()
        {
            spriteRenderer.sprite = null;
            gameObject.SetActive(false);
            Controller.OnPopAnimationPlayed();
        }

    }
}