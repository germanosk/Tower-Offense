namespace BeardTwins.TO
{
    public interface IDamageable
    {

        /// <summary>
        /// Apply some damage
        /// </summary>
        /// <param name="damage">Ammount of damage to be applied</param>
        /// <returns>True if IDamageable was destroied</returns>
        bool ApplyDamage(float damage);
        void BackToDefault();
    }
}
