namespace ET
{
    namespace EventIdType
    {
        public struct AppStart
        {
        }

        public struct ChangePosition
        {
            public Unit Unit;
        }

        public struct ChangeRotation
        {
            public Unit Unit;
        }

        public struct PingChange
        {
            public Scene ZoneScene;
            public long Ping;
        }
        
        public struct AfterCreateScene
        {
            public Scene Scene;
        }
        
        public struct AfterCreateLoginScene
        {
            public Scene LoginScene;
        }

        public struct AppStartInitFinish
        {
            public Scene Scene;
        }

        public struct LoginFinish
        {
            public Scene ZoneScene;
        }

        public struct LoadingBegin
        {
            public Scene Scene;
        }

        public struct LoadingFinish
        {
            public Scene Scene;
        }

        public struct StartChangeScene
        {
            public Scene ZoneScene;
            public int MapConfigId;
        }

        public struct AfterUnitCreate
        {
            public Unit Unit;
        }
        
        public struct MoveStart
        {
            public Unit Unit;
        }

        public struct MoveStop
        {
            public Unit Unit;
        }

        public struct CastSpell
        {
            public Spell spell;
        }

        public struct InterruptSpell
        {
            public Spell spell;
        }
        
        public struct NumbericChange
        {
            public Unit Unit;
            public NumericType NumericType;
            public long Old;
            public long New;
        }

        public struct ExcuteBT
        {
            public BTSwitch BtSwitch;
            public Entity entity;
        }

        public struct DamageResult
        {
            public Unit Target;
            public DamageResultType Type;
            public long damage;
        }

        public struct PutOnEquip
        {
            public Unit unit;
            public int EquipPoint;
            public Item Item;
        }

        public struct PutDownEquip
        {
            public Unit unit;
            public int EquipPoint;
            public Item Item;
        }

        public struct OnUnitDie
        {
            public Unit caster;
            public Unit target;
        }
        
        public struct OnUnitRevive
        {
            public Unit target;
        }

        public struct InventoryAdd
        {
            public Scene scene;
            public int Pos;
            public Item Item;
        }
        
        public struct InventoryRemove
        {
            public Scene scene;
            public int Pos;
            public Item Item;
        }
    }
}