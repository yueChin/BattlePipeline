using System;

namespace Pipeline.Battle
{

    public partial struct Numeric
    {
        public static Numeric Create(Type type)
        {
            switch (type)
            {
                case Type.Int16:
                    return Create((Int16)0);
                    break;
                case Type.UInt16:
                    return Create((UInt16)0);
                    break;
                case Type.Int32:
                    return Create((Int32)0);
                    break;
                case Type.UInt32:
                    return Create((UInt32)0);
                    break;
                case Type.Int64:
                    return Create((Int64)0);
                    break;
                case Type.UInt64:
                    return Create((UInt64)0);
                    break;
                case Type.Single:
                    return Create((Single)0);
                    break;
                case Type.Double:
                    return Create((Double)0);
                    break;
            }
            return Create((Int32)0);
        }
        
        public static Numeric Create(short val)
        {
            return new Numeric
            {
                m_Type = Type.Int16,
                m_Val = new Value { _int16 = val }
            };
        }

        public static Numeric Create(ushort val)
        {
            return new Numeric
            {
                m_Type = Type.UInt16,
                m_Val = new Value { _uint16 = val }
            };
        }

        public static Numeric Create(int val)
        {
            return new Numeric
            {
                m_Type = Type.Int32,
                m_Val = new Value { _int32 = val }
            };
        }

        public static Numeric Create(uint val)
        {
            return new Numeric
            {
                m_Type = Type.UInt32,
                m_Val = new Value { _uint32 = val }
            };
        }

        public static Numeric Create(long val)
        {
            return new Numeric
            {
                m_Type = Type.Int64,
                m_Val = new Value { _int64 = val }
            };
        }

        public static Numeric Create(ulong val)
        {
            return new Numeric
            {
                m_Type = Type.UInt64,
                m_Val = new Value { _uint64 = val }
            };
        }

        public static Numeric Create(ref long val)
        {
            return new Numeric
            {
                m_Type = Type.Int64,
                m_Val = new Value { _int64 = val }
            };
        }

        public static Numeric Create(ref ulong val)
        {
            return new Numeric
            {
                m_Type = Type.UInt64,
                m_Val = new Value { _uint64 = val }
            };
        }

        public static Numeric Create(float val)
        {
            return new Numeric
            {
                m_Type = Type.Single,
                m_Val = new Value { _single = val }
            };
        }

        public static Numeric Create(double val)
        {
            return new Numeric
            {
                m_Type = Type.Double,
                m_Val = new Value { _double = val }
            };
        }

        public static Numeric Create(ref double val)
        {
            return new Numeric
            {
                m_Type = Type.Double,
                m_Val = new Value { _double = val }
            };
        }
    }
}
//EOF
