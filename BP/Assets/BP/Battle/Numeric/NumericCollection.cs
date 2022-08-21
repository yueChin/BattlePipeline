using System.Collections.Generic;

namespace Pipeline.Battle
{
    public class NumericCollection
    {
        private Numeric m_BaseValue;
        public List<Numeric> ValueList = new List<Numeric>();

        public Numeric Value
        {
            get
            {
                Numeric value = Numeric.Create(m_BaseValue.ValueType);
                foreach (Numeric t in ValueList)
                {
                    value += t;
                }
                return value;
            }
        }
        
        public NumericCollection(short value)
        {
            m_BaseValue = Numeric.Create(value);
        }
        
        public NumericCollection(ushort value)
        {
            m_BaseValue = Numeric.Create(value);
        }
        
        public NumericCollection(int value)
        {
            m_BaseValue = Numeric.Create(value);
        }
        
        public NumericCollection(uint value)
        {
            m_BaseValue = Numeric.Create(value);
        }
        
        public NumericCollection(long value)
        {
            m_BaseValue = Numeric.Create(value);
        }
        
        public NumericCollection(ulong value)
        {
            m_BaseValue = Numeric.Create(value);
        }
        
        public NumericCollection(float value)
        {
            m_BaseValue = Numeric.Create(value);
        }
        
        public NumericCollection(double value)
        {
            m_BaseValue = Numeric.Create(value);
        }
        
        public NumericCollection(Numeric value)
        {
            m_BaseValue = value;
        }
        
        public void AddValue(Numeric value)
        {
            if (value.ValueType != m_BaseValue.ValueType)
            {
                return;
            }
            ValueList.Add(value);
        }

        public void RemoveValue(Numeric value)
        {
            if (value.ValueType != m_BaseValue.ValueType)
            {
                return;
            }
            ValueList.Remove(value);
        }
    }
}