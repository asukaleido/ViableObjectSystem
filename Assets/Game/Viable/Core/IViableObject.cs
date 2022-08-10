using UniRx;

namespace Game.Viable.Core
{
    /// <summary>
    /// 実行可能オブジェクトの基底インターフェース
    /// </summary>
    public interface IViableObject
    {
        /// <summary>
        /// 固有識別子
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 説明文
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// 他の実行可能オブジェクトを実行できるようになるまでにかかる時間
        /// </summary>
        public float CooldownTime { get; }

        /// <summary>
        /// 実行可能オブジェクトを基底に持つ同一クラスをもう一度実行できるようになるまでにかかる時間
        /// </summary>
        public float RecastTime { get; }

        /// <summary>
        /// 実行
        /// </summary>
        public void Action();
    }
}