namespace Game.Viable.Core
{
    /// <summary>
    /// Effectクラスの実行対象を現す
    /// <see cref="Effect"/>
    /// </summary>
    public enum Target
    {
        /// <summary>
        /// 未設定
        /// </summary>
        None,

        /// <summary>
        /// 自身
        /// </summary>
        Self,

        /// <summary>
        /// 敵
        /// </summary>
        Enemy,

        /// <summary>
        /// 前方
        /// </summary>
        Forward,

        /// <summary>
        /// 範囲
        /// </summary>
        AoE,
    }
}