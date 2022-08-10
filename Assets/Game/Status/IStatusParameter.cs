namespace Game.Status
{
    /// <summary>
    /// 全キャラクターに共通する基礎ステータスを現すオブジェクトの基底インターフェース
    /// </summary>
    public interface IStatusParameter
    {
        /// <summary>
        /// 攻撃力
        /// </summary>
        public float Atk { get; }

        /// <summary>
        /// 体力
        /// </summary>
        public float Vit { get; }

        /// <summary>
        /// 防御力
        /// </summary>
        public float Def { get; }

        /// <summary>
        /// 知力
        /// </summary>
        public float Int { get; }
    }
}