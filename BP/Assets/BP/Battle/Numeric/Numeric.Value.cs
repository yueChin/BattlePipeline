using System;
using System.Runtime.InteropServices;

namespace Pipeline.Battle
{

    public partial struct Numeric
    {
        
        [StructLayout(LayoutKind.Explicit)]
        internal struct Value
        {
            [FieldOffset(0)] internal Int16 _int16;

            [FieldOffset(0)] internal UInt16 _uint16;

            [FieldOffset(0)] internal Int32 _int32;

            [FieldOffset(0)] internal UInt32 _uint32;

            [FieldOffset(0)] internal Int64 _int64;

            [FieldOffset(0)] internal UInt64 _uint64;

            [FieldOffset(0)] internal Single _single;

            [FieldOffset(0)] internal Double _double;
            
        };
    }
}
//EOF
