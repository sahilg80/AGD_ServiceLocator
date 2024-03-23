using UnityEngine;

namespace ServiceLocator.Wave.Bloon
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BloonView : MonoBehaviour
    {
        public BloonController Controller { get ; set ; }

        private SpriteRenderer spriteRenderer;
        private Animator animator;
        private bool isThisBloonBoss;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            CheckBloonType();
        }

        private void CheckBloonType()
        {
            isThisBloonBoss = Controller.IsBloonTypeBoss();
        }

        private void Update()
        {
            if (isThisBloonBoss && Controller.IsItTheTimeToRegenerate())
            {
                Controller.RegenerateHealth();
            }
            Controller.FollowWayPoints();
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