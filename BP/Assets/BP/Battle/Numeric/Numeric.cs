
namespace Pipeline.Battle
{

    public partial struct Numeric
    {

        static Numeric()
        {
            s_Nil.m_Type = Type.Int32;
        }

        static readonly Numeric s_Nil;

        public static Numeric Zero
        {
            get { return s_Nil; }
        }

        public enum Type
        {
            Int16 = 7,
            UInt16 = 8,
            Int32 = 9,
            UInt32 = 10,
            Int64 = 11,
            UInt64 = 12,
            Single = 13,
            Double = 14,
        }

        private Type m_Type;
        private Value m_Val;

        public Type ValueType => m_Type;
    }
}
//EOF
