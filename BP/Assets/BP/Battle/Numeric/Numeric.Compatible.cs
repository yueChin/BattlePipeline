using System;

namespace Pipeline.Battle
{
    public partial struct Numeric :
        IComparable,
        IConvertible,
        IFormattable
    {
        public int CompareTo(object obj)
        {
            return 0;
        }

        public TypeCode GetTypeCode()
        {
            return (TypeCode)((int)m_Type);
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return ToBoolean();
        }

        public byte ToByte(IFormatProvider provider)
        {
            return ToByte();
        }

        public char ToChar(IFormatProvider provider)
        {
            return ToChar();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return DateTime.Now;
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return ToDecimal();
        }

        public double ToDouble(IFormatProvider provider)
        {
            return ToDouble();
        }

        public short ToInt16(IFormatProvider provider)
        {
            return ToInt16();
        }

        public int ToInt32(IFormatProvider provider)
        {
            return ToInt32();
        }

        public long ToInt64(IFormatProvider provider)
        {
            return ToInt64();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return ToSByte();
        }

        public float ToSingle(IFormatProvider provider)
        {
            return ToSingle();
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }

        public object ToType(System.Type conversionType, IFormatProvider provider)
        {
            return null!;
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return ToUInt16();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return ToUInt32();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return ToUInt64();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString();
        }
    }
}
//EOF
