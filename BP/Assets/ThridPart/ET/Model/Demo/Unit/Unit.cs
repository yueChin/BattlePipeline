using System;
using MongoDB.Bson.Serialization.Attributes;
using UnityEngine;

namespace ET
{
    [BsonIgnoreExtraElements]
    public sealed class Unit: Entity
    {
        public int ConfigId; //配置表id

        [BsonIgnore]
        public UnitConfig Config => UnitConfigCategory.Instance.Get(this.ConfigId);

        private Vector3 position; //坐标

        public Vector3 Position
        {
            get => this.position;
            set
            {
                this.position = value;
                Game.EventSystem.Run(new EventIdType.ChangePosition() { Unit = this }).Coroutine();
            }
        }

        [BsonIgnore]
        public Vector3 Forward
        {
            get => this.Rotation * Vector3.forward;
            set
            {
                value = new Vector3(value.x, 0, value.z);
                this.Rotation = Quaternion.LookRotation(value, Vector3.up);
            }
        }

        private Quaternion rotation;
        public Quaternion Rotation
        {
            get => this.rotation;
            set
            {
                this.rotation = value;
                Game.EventSystem.Run(new EventIdType.ChangeRotation() {Unit = this}).Coroutine();
            }
        }
    }
}