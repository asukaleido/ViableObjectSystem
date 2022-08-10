using Game.Viable.Core;
using UniRx;

namespace Game.Viable.Item
{
    /// <summary>
    /// 魔導書
    /// </summary>
    public class SpellbookObject : InstantItemObject
    {
        public SkillObject Skill { get; }

        private SpellbookObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            IEffect effect,
            SkillObject skill
        ) : base(id, name, description, cooldownTime, recastTime, cooldownTimeSubject, effect)
        {
            Skill = skill;
        }

        /// <summary>
        /// インスタンス生成
        /// </summary>
        /// <param name="id">固有識別子</param>
        /// <param name="name">名前</param>
        /// <param name="description">説明文</param>
        /// <param name="cooldownTime">クールダウンタイム(1-6秒)</param>
        /// <param name="recastTime">リキャストタイム(1-180秒)</param>
        /// <param name="cooldownTimeSubject">クールダウンタイム購読インスタンス</param>
        /// <param name="skill">スキル</param>
        /// <returns>魔導書のインスタンス</returns>
        public static SpellbookObject CreateObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            SkillObject skill
        )
        {
            ValidationCheck.CooldownTime(cooldownTime);
            ValidationCheck.RecastTime(recastTime);
            Effect effect = Core.Effect.None;
            return new SpellbookObject(
                id,
                name,
                description,
                cooldownTime,
                recastTime,
                cooldownTimeSubject,
                skill.Effect,
                skill
            );
        }
    }
}