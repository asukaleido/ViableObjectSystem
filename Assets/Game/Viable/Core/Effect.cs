namespace Game.Viable.Core
{
    /// <summary>
    /// 実行可能オブジェクトを実行した際に及ぼす影響
    /// </summary>
    public struct Effect : IEffect
    {
        public EffectType Type { get; }
        public Target Target { get; }
        public float Range { get; }

        /// <summary>
        /// 威力
        /// 種別によって影響させるパラメータが異なる
        /// </summary>
        public float Potency { get; }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="type">種別</param>
        /// <param name="target">実行対象</param>
        /// <param name="range">影響範囲</param>
        /// <param name="potency">威力</param>
        public Effect(
            EffectType type,
            Target target,
            float range,
            float potency
        )
        {
            Type = type;
            Target = target;
            Range = range;
            Potency = potency;
        }

        /// <summary>
        /// 未設定
        /// </summary>
        public static Effect None = new Effect(
            type: EffectType.None,
            target: Target.None,
            range: 0f,
            potency: 0f
        );
    }
}