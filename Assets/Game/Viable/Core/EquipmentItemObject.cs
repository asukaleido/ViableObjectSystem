using System;
using System.Collections.Generic;
using Game.Status;
using UniRx;

namespace Game.Viable.Core
{
    /// <summary>
    /// 装備可能な実行可能オブジェクト
    /// </summary>
    public abstract class EquipmentItemObject : ViableObject, IEquipableObject
    {
        private readonly Subject<IEquipableObject> _registerEquipmentSubject;
        private readonly Subject<IEquipableObject> _unregisterEquipmentSubject;

        public abstract EquipmentType EquipmentType { get; }
        public abstract StatusParameter StatusParameter { get; }
        public List<SkillObject> SkillList { get; }

        public IObservable<IEquipableObject> RegisterEquipmentObservable =>
            _registerEquipmentSubject.AsObservable();

        public IObservable<IEquipableObject> UnregisterEquipmentObservable =>
            _unregisterEquipmentSubject.AsObservable();

        public bool Registered { get; private set; }

        protected EquipmentItemObject(
            int id,
            string name,
            string description,
            float cooldownTime,
            float recastTime,
            BehaviorSubject<float> cooldownTimeSubject,
            List<SkillObject> skillList
        ) : base(
            id,
            name,
            description,
            cooldownTime,
            recastTime,
            cooldownTimeSubject
        )
        {
            _registerEquipmentSubject = new Subject<IEquipableObject>();
            _unregisterEquipmentSubject = new Subject<IEquipableObject>();

            SkillList = skillList;
            Registered = false;
        }

        public override void Action()
        {
            if (!IsViable()) return;

            if (Registered)
            {
                Register();
            }
            else
            {
                Unregister();
            }

            base.Action();
        }

        public virtual void Register()
        {
            if (Registered) return;

            Registered = true;
            foreach (SkillObject skill in SkillList)
            {
                skill.SetEnabled(true);
            }

            _registerEquipmentSubject.OnNext(this);
        }

        public virtual void Unregister()
        {
            if (!Registered) return;

            Registered = false;
            foreach (SkillObject skill in SkillList)
            {
                skill.SetEnabled(false);
            }

            _unregisterEquipmentSubject.OnNext(this);
        }
    }
}