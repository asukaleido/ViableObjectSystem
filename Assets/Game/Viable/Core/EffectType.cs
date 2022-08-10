namespace Game.Viable.Core
{
    /// <summary>
    /// Effectクラスの種別
    /// <see cref="Effect"/>
    /// </summary>
    public enum EffectType
    {
        /// <summary>
        /// 未設定
        /// </summary>
        None,

        /// <summary>
        /// 物理攻撃
        /// </summary>
        PhysicalAttack,

        /// <summary>
        /// HP回復
        /// </summary>
        HpRecovery,

        /// <summary>
        /// MP回復
        /// </summary>
        MpRecovery,
    }
}