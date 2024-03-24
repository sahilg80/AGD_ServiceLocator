using System;
using System.Collections;
using UnityEngine;

namespace ServiceLocator.Wave.Bloon
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BloonView : MonoBehaviour
    {
        private const float totalDuration = 3f;
        private const float startTime = 0f;
        public BloonController Controller { get ; set ; }
        private SpriteRenderer spriteRenderer;
        private Animator animator;
        public event Action OnRegeneratingHealth;
        public event Action OnPopAnimationPlayed;
        public event Action OnFollowWayPoints;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
        }

        private void Update()
        {
            OnFollowWayPoints?.Invoke();
        }

        public void CheckBloonTypeToStartTimer(bool value)
        {
            bool isThisBloonBoss = value;
            if (isThisBloonBoss)
            {
                StartCoroutine(TimerToRegenerate());
            }
        }

        private IEnumerator TimerToRegenerate()
        {
            float timeElapsed = startTime;
            while (true)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= totalDuration)
                {
                    // invoke event to regenerate health
                    OnRegeneratingHealth?.Invoke();
                    timeElapsed = startTime;
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
            OnPopAnimationPlayed?.Invoke();
        }

    }
}