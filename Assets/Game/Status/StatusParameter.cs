namespace Game.Status
{
    /// <summary>
    /// 全キャラクターに共通する基礎ステータスを現すオブジェクト
    /// </summary>
    public class StatusParameter : IStatusParameter
    {
        public float Atk { get; }
        public float Vit { get; }
        public float Def { get; }
        public float Int { get; }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="a">攻撃力</param>
        /// <param name="v">体力</param>
        /// <param name="d">防御力</param>
        /// <param name="i">知力</param>
        public StatusParameter(
            float a,
            float v,
            float d,
            float i
        )
        {
            Atk = a;
            Vit = v;
            Def = d;
            Int = i;
        }
    }
}