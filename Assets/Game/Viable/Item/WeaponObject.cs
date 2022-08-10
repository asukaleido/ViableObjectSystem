using System.Collections.Generic;
using Game.Status;
using Game.Viable.Core;
using UniRx;

namespace Game.Viable.Item
{
    /// <summary>
    /// 武器
    /// </summary>
    public class WeaponObject : EquipmentItemObject
    {
        public override EquipmentType EquipmentType => EquipmentType.RightHand;
        public override StatusParameter StatusParameter { get; }

        private WeaponObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            float attack,
            List<SkillObject> skillList
        ) : base(id, name, description, cooldownTime, recastTime, cooldownTimeSubject, skillList)
        {
            StatusParameter = new StatusParameter(a: attack, v: 0f, d: 0f, i: 0f);
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
        /// <param name="attack">攻撃力</param>
        /// <param name="skillList">スキルリスト</param>
        /// <returns>武器のインスタンス</returns>
        public static WeaponObject CreateObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            float attack,
            List<SkillObject> skillList
        )
        {
            ValidationCheck.CooldownTime(cooldownTime);
            ValidationCheck.RecastTime(recastTime);
            return new WeaponObject(
                id,
                name,
                description,
                cooldownTime,
                recastTime,
                cooldownTimeSubject,
                attack,
                skillList
            );
        }
    }
}