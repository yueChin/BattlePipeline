
namespace Pipeline.Battle
{

    public partial struct Numeric
    {
        public static Numeric operator -(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() - b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() - b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() - b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() - b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() - b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() - b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() - b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() - b.ToDouble());
                  
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() - b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() - b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() - b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() - b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() - b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() - b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() - b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() - b.ToDouble());
                  
                }
            }
            return Create(a.ToUInt32() - b.ToUInt32());
        }
        
        public static Numeric operator +(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() + b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() + b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() + b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() + b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() + b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() + b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() + b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() + b.ToDouble());
                  
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() + b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() + b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() + b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() + b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() + b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() + b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() + b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() + b.ToDouble());
                  
                }
            }
            return Create(a.ToInt32() + b.ToInt32());
        }
        
        public static Numeric operator *(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() * b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() * b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() * b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() * b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() * b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() * b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() * b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() * b.ToDouble());
                  
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() * b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() * b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() * b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() * b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() * b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() * b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() * b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() * b.ToDouble());
                  
                }
            }
            return Create(a.ToUInt32() * b.ToUInt32());
        }
        
        public static Numeric operator /(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() / b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() / b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() / b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() / b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() / b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() / b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() / b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() / b.ToDouble());
                  
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() / b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() / b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() / b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() / b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() / b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() / b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() / b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() / b.ToDouble());
                  
                }
            }
            return Create(a.ToUInt32() / b.ToUInt32());
        }
        
        public static Numeric operator %(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() % b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() % b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() % b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() % b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() % b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() % b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() % b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() % b.ToDouble());
                  
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return Create(a.ToInt16() % b.ToInt16());
                    case Type.UInt16:
                        return Create(a.ToUInt16() % b.ToUInt16());
                    case Type.Int32:
                        return Create(a.ToInt32() % b.ToInt32());
                    case Type.UInt32:
                        return Create(a.ToUInt32() % b.ToUInt32());
                    case Type.Int64:
                        return Create(a.ToInt64() % b.ToInt64());
                    case Type.UInt64:
                        return Create(a.ToUInt64() % b.ToUInt64());
                    case Type.Single:
                        return Create(a.ToSingle() % b.ToSingle());
                    case Type.Double:
                        return Create(a.ToDouble() % b.ToDouble());
                  
                }
            }
            return Create(a.ToUInt32() % b.ToUInt32());
        }
        
        public static bool operator >(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() > b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() > b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() > b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() > b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() > b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() > b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() > b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() > b.ToDouble();
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() > b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() > b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() > b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() > b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() > b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() > b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() > b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() > b.ToDouble();
                  
                }
            }
            return a.ToInt32() > b.ToInt32();
        }
        
        public static bool operator <(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() < b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() < b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() < b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() < b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() < b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() < b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() < b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() < b.ToDouble();
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() < b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() < b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() < b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() < b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() < b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() < b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() < b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() < b.ToDouble();
                  
                }
            }
            return a.ToInt32() < b.ToInt32();
        }
        
        public static bool operator >=(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() >= b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() >= b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() >= b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() >= b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() >= b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() >= b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() >= b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() >= b.ToDouble();
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() >= b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() >= b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() >= b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() >= b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() >= b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() >= b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() >= b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() >= b.ToDouble();
                  
                }
            }
            return a.ToInt32() >= b.ToInt32();
        }
        
        public static bool operator <=(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() <= b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() <= b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() <= b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() <= b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() <= b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() <= b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() <= b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() <= b.ToDouble();
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() <= b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() <= b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() <= b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() <= b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() <= b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() <= b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() <= b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() <= b.ToDouble();
                  
                }
            }
            return a.ToInt32() <= b.ToInt32();
        }
        
        public static bool operator ==(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() == b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() == b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() == b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() == b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() == b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() == b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() == b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() == b.ToDouble();
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() == b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() == b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() == b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() == b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() == b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() == b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() == b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() == b.ToDouble();
                  
                }
            }
            return a.ToInt32() == b.ToInt32();
        }
        
        public static bool operator !=(Numeric a,Numeric b)
        {
            if ((int)a.ValueType >= (int)b.ValueType)
            {
                switch (a.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() != b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() != b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() != b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() != b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() != b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() != b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() != b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() != b.ToDouble();
                }
            }
            else 
            {
                switch (b.ValueType)
                {
                    case Type.Int16:
                        return a.ToInt16() != b.ToInt16();
                    case Type.UInt16:
                        return a.ToUInt16() != b.ToUInt16();
                    case Type.Int32:
                        return a.ToInt32() != b.ToInt32();
                    case Type.UInt32:
                        return a.ToUInt32() != b.ToUInt32();
                    case Type.Int64:
                        return a.ToInt64() != b.ToInt64();
                    case Type.UInt64:
                        return a.ToUInt64() != b.ToUInt64();
                    case Type.Single:
                        return a.ToSingle() != b.ToSingle();
                    case Type.Double:
                        return a.ToDouble() != b.ToDouble();
                  
                }
            }
            return a.ToInt32() != b.ToInt32();
        }
    }
}
//EOF
