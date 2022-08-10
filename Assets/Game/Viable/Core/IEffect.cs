namespace Game.Viable.Core
{
    /// <summary>
    /// 実行可能オブジェクトを実行した際に及ぼす影響の基底インターフェース
    /// </summary>
    public interface IEffect
    {
        /// <summary>
        /// 種別
        /// </summary>
        public EffectType Type { get; }

        /// <summary>
        /// 実行対象
        /// </summary>
        public Target Target { get; }

        /// <summary>
        /// 影響範囲
        /// </summary>
        public float Range { get; }
    }
}