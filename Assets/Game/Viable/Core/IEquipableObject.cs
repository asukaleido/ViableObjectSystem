using System;
using System.Collections.Generic;
using Game.Status;

namespace Game.Viable.Core
{
    /// <summary>
    /// 装備可能なオブジェクトの基底インターフェース
    /// </summary>
    public interface IEquipableObject
    {
        /// <summary>
        /// 装備箇所
        /// </summary>
        public EquipmentType EquipmentType { get; }

        /// <summary>
        /// ステータスパラメータ
        /// </summary>
        public StatusParameter StatusParameter { get; }

        /// <summary>
        /// スキルリスト
        /// </summary>
        public List<SkillObject> SkillList { get; }

        /// <summary>
        /// 装備登録
        /// </summary>
        public IObservable<IEquipableObject> RegisterEquipmentObservable { get; }

        /// <summary>
        /// 装備解除
        /// </summary>
        public IObservable<IEquipableObject> UnregisterEquipmentObservable { get; }

        /// <summary>
        /// 装備状態
        /// </summary>
        bool Registered { get; }

        /// <summary>
        /// 装備する
        /// </summary>
        public void Register();

        /// <summary>
        /// 装備を外す
        /// </summary>
        public void Unregister();
    }
}