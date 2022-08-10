using System;

namespace Game.Viable.Core
{
    /// <summary>
    /// 影響を及ぼすオブジェクトの基底インターフェース
    /// </summary>
    public interface IEffectiveObject
    {
        /// <summary>
        /// 実行した際に及ぼす影響
        /// </summary>
        public IEffect Effect { get; }

        /// <summary>
        /// 使用可否
        /// </summary>
        public bool Enabled { get; }

        /// <summary>
        /// 効果発動
        /// </summary>
        public IObservable<IEffect> IgnitionEffectObservable { get; }
    }
}