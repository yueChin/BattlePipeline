using System;

namespace Pipeline.Battle
{

    public partial struct Numeric
    {
        public Numeric Convert(Type type)
        {
            switch (type)
            {
                case Type.Int16:
                    return Create(ToInt16());
                    break;
                case Type.UInt16:
                    return Create(ToUInt16());
                    break;
                case Type.Int32:
                    return Create(ToInt32());
                    break;
                case Type.UInt32:
                    return Create(ToUInt32());
                    break;
                case Type.Int64:
                    return Create(ToInt64());
                    break;
                case Type.UInt64:
                    return Create(ToUInt64());
                    break;
                case Type.Single:
                    return Create(ToSingle());
                    break;
                case Type.Double:
                    return Create(ToDouble());
                    break;
            }
            return Create((Int32)0);
        }
        
        
        public Int16 ToInt16()
        {
            switch (m_Type)
            {
                case Type.Int16:
                    return m_Val._int16;
                case Type.UInt16:
                    return (Int16)m_Val._uint16;
                case Type.Int32:
                    return (Int16)m_Val._int32;
                case Type.UInt32:
                    return (Int16)m_Val._uint32;
                case Type.Int64:
                    return (Int16)m_Val._int64;
                case Type.UInt64:
                    return (Int16)m_Val._uint64;
                case Type.Single:
                    return (Int16)m_Val._single;
                case Type.Double:
                    return (Int16)m_Val._double;
            }

            return 0;
        }

        public UInt16 ToUInt16()
        {
            switch (m_Type)
            {
                case Type.UInt16:
                    return m_Val._uint16;
                case Type.Int16:
                    return (UInt16)m_Val._int16;
                case Type.Int32:
                    return (UInt16)m_Val._int32;
                case Type.UInt32:
                    return (UInt16)m_Val._uint32;
                case Type.Int64:
                    return (UInt16)m_Val._int64;
                case Type.UInt64:
                    return (UInt16)m_Val._uint64;
                case Type.Single:
                    return (UInt16)m_Val._single;
                case Type.Double:
                    return (UInt16)m_Val._double;
            }

            return 0;
        }

        public Int32 ToInt32()
        {
            switch (m_Type)
            {
                case Type.Int32:
                    return m_Val._int32;
                case Type.UInt32:
                    return (Int32)m_Val._uint32;
                case Type.UInt16:
                    return (Int32)m_Val._uint16;
                case Type.Int16:
                    return (Int32)m_Val._int16;
                case Type.Int64:
                    return (Int32)m_Val._int64;
                case Type.UInt64:
                    return (Int32)m_Val._uint64;
                case Type.Single:
                    return (Int32)m_Val._single;
                case Type.Double:
                    return (Int32)m_Val._double;
            }

            return 0;
        }

        public UInt32 ToUInt32()
        {
            switch (m_Type)
            {
                case Type.UInt32:
                    return m_Val._uint32;
                case Type.UInt16:
                    return (UInt32)m_Val._uint16;
                case Type.Int16:
                    return (UInt32)m_Val._int16;
                case Type.Int32:
                    return (UInt32)m_Val._int32;
                case Type.Int64:
                    return (UInt32)m_Val._int64;
                case Type.UInt64:
                    return (UInt32)m_Val._uint64;
                case Type.Single:
                    return (UInt32)m_Val._single;
                case Type.Double:
                    return (UInt32)m_Val._double;
            }

            return 0;
        }

        public Int64 ToInt64()
        {
            switch (m_Type)
            {
                case Type.Int64:
                    return m_Val._int64;
                case Type.Int32:
                    return (Int64)m_Val._int32;
                case Type.UInt32:
                    return (Int64)m_Val._uint32;
                case Type.UInt16:
                    return (Int64)m_Val._uint16;
                case Type.Int16:
                    return (Int64)m_Val._int16;
                case Type.UInt64:
                    return (Int64)m_Val._uint64;
                case Type.Single:
                    return (Int64)m_Val._single;
                case Type.Double:
                    return (Int64)m_Val._double;
            }

            return 0;
        }

        public UInt64 ToUInt64()
        {
            switch (m_Type)
            {
                case Type.UInt64:
                    return m_Val._uint64;
                case Type.Int64:
                    return (UInt64)m_Val._int64;
                case Type.Int32:
                    return (UInt64)m_Val._int32;
                case Type.UInt32:
                    return (UInt64)m_Val._uint32;
                case Type.UInt16:
                    return (UInt64)m_Val._uint16;
                case Type.Int16:
                    return (UInt64)m_Val._int16;
                case Type.Single:
                    return (UInt64)m_Val._single;
                case Type.Double:
                    return (UInt64)m_Val._double;
            }

            return 0;
        }

        public Single ToSingle()
        {
            switch (m_Type)
            {
                case Type.Single:
                    return m_Val._single;
                case Type.UInt64:
                    return (Single)m_Val._uint64;
                case Type.Int64:
                    return (Single)m_Val._int64;
                case Type.Int32:
                    return (Single)m_Val._int32;
                case Type.UInt32:
                    return (Single)m_Val._uint32;
                case Type.UInt16:
                    return (Single)m_Val._uint16;
                case Type.Int16:
                    return (Single)m_Val._int16;
                case Type.Double:
                    return (Single)m_Val._double;
            }

            return 0;
        }

        public Double ToDouble()
        {
            switch (m_Type)
            {
                case Type.Double:
                    return m_Val._double;
                case Type.Single:
                    return (Double)m_Val._single;
                case Type.UInt64:
                    return (Double)m_Val._uint64;
                case Type.Int64:
                    return (Double)m_Val._int64;
                case Type.Int32:
                    return (Double)m_Val._int32;
                case Type.UInt32:
                    return (Double)m_Val._uint32;
                case Type.UInt16:
                    return (Double)m_Val._uint16;
                case Type.Int16:
                    return (Double)m_Val._int16;
            }

            return 0;
        }
        
        public Decimal ToDecimal()
        {
            switch (m_Type)
            {
                case Type.Double:
                    return (Decimal)m_Val._double;
                case Type.Single:
                    return (Decimal)m_Val._single;
                case Type.UInt64:
                    return (Decimal)m_Val._uint64;
                case Type.Int64:
                    return (Decimal)m_Val._int64;
                case Type.Int32:
                    return (Decimal)m_Val._int32;
                case Type.UInt32:
                    return (Decimal)m_Val._uint32;
                case Type.UInt16:
                    return (Decimal)m_Val._uint16;
                case Type.Int16:
                    return (Decimal)m_Val._int16;
            }

            return 0;
        }
        
        public override String ToString()
        {
            switch (m_Type)
            {
                case Type.Double:
                    return m_Val._double.ToString();
                case Type.Single:
                    return m_Val._single.ToString();
                case Type.UInt64:
                    return m_Val._uint64.ToString();
                case Type.Int64:
                    return m_Val._int64.ToString();
                case Type.Int32:
                    return m_Val._int32.ToString();
                case Type.UInt32:
                    return m_Val._uint32.ToString();
                case Type.UInt16:
                    return m_Val._uint16.ToString();
                case Type.Int16:
                    return m_Val._int16.ToString();
            }
            return String.Empty;
        }

        public bool ToBoolean()
        {
            switch (m_Type)
            {
                case Type.Int16:
                case Type.UInt16:
                    return m_Val._int16 != 0;
                case Type.Int32:
                case Type.UInt32:
                    return m_Val._int32 != 0;
                case Type.Int64:
                case Type.UInt64:
                    return m_Val._int64 != 0;
                case Type.Single:
                    return m_Val._single != 0;
                case Type.Double:
                    return m_Val._double != 0;
            }

            return false;
        }

        public SByte ToSByte()
        {
            switch (m_Type)
            {
                case Type.Int16:
                    return (SByte)m_Val._int16;
                case Type.UInt16:
                    return (SByte)m_Val._uint16;
                case Type.Int32:
                    return (SByte)m_Val._int32;
                case Type.UInt32:
                    return (SByte)m_Val._uint32;
                case Type.Int64:
                    return (SByte)m_Val._int64;
                case Type.UInt64:
                    return (SByte)m_Val._uint64;
                case Type.Single:
                    return (SByte)m_Val._single;
                case Type.Double:
                    return (SByte)m_Val._double;
            }

            return 0;
        }

        public Byte ToByte()
        {
            switch (m_Type)
            {
                case Type.Int16:
                    return (Byte)m_Val._int16;
                case Type.UInt16:
                    return (Byte)m_Val._uint16;
                case Type.Int32:
                    return (Byte)m_Val._int32;
                case Type.UInt32:
                    return (Byte)m_Val._uint32;
                case Type.Int64:
                    return (Byte)m_Val._int64;
                case Type.UInt64:
                    return (Byte)m_Val._uint64;
                case Type.Single:
                    return (Byte)m_Val._single;
                case Type.Double:
                    return (Byte)m_Val._double;
            }

            return 0;
        }

        public Char ToChar()
        {
            switch (m_Type)
            {
                case Type.Int16:
                    return (Char)m_Val._int16;
                case Type.UInt16:
                    return (Char)m_Val._uint16;
                case Type.Int32:
                    return (Char)m_Val._int32;
                case Type.UInt32:
                    return (Char)m_Val._uint32;
                case Type.Int64:
                    return (Char)m_Val._int64;
                case Type.UInt64:
                    return (Char)m_Val._uint64;
                case Type.Single:
                    return (Char)m_Val._single;
                case Type.Double:
                    return (Char)m_Val._double;
            }

            return '\0';
        }
    }
}
//EOF
