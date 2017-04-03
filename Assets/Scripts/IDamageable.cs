using UnityEngine;
namespace BeardTwins.TO
{
    public abstract class IDamageable: MonoBehaviour
    {

        public float life;
        protected float currentLife;

        [SerializeField]
        protected SpriteRenderer lifeBar;

        protected Vector2 barStartPosition;
        protected float originalWidth;

        protected void Start()
        {
            originalWidth = lifeBar.sprite.bounds.size.x / 2;
            barStartPosition = lifeBar.transform.localPosition;
            currentLife = life;
            UpdateLifeBar();
        }

        /// <summary>
        /// Apply some damage
        /// </summary>
        /// <param name="damage">Ammount of damage to be applied</param>
        /// <returns>True if IDamageable was destroied</returns>
        public abstract bool ApplyDamage(float damage);

        public abstract void BackToDefault();

        protected void UpdateLifeBar()
        {
            float lifeRatio = currentLife / life;
            lifeBar.transform.localScale = new Vector3(lifeRatio, 1.0f, 1.0f);

            lifeBar.transform.localPosition = barStartPosition - new Vector2(originalWidth - (originalWidth * lifeRatio), 0);
            if (lifeRatio < 0.25f)
            {
                lifeBar.color = Constants.DyingColor;
            }
            else if (lifeRatio <= 0.75f)
            {
                lifeBar.color = Constants.WarningColor;
            }
            else
            {
                lifeBar.color = Constants.HealthyColor;
            }
        }
    }
}
