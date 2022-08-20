using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    [AttributeUsage(AttributeTargets.Field,AllowMultiple = false)]
    public class GUI_BgColorAttribute : BaseAttribute
    {
        public float r;
        public float g;
        public float b;
        public float a;

        //一般常见的 ,这里标注为float(0,1) 但为了方便填写,所以用(0,255)
        public GUI_BgColorAttribute(byte r, byte g, byte b, byte a = 255)
        {
            this.r = r / 255.0f;
            this.g = g / 255.0f;
            this.b = b / 255.0f;
            this.a = a / 255.0f;
        }

        public GUI_BgColorAttribute(float r, float g, float b, float a = 1)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GUI_LabelColorAttribute : BaseAttribute
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public GUI_LabelColorAttribute(byte r, byte g, byte b, byte a = 255)
        {
            this.r = r / 255.0f;
            this.g = g / 255.0f;
            this.b = b / 255.0f;
            this.a = a / 255.0f;
        }

        public GUI_LabelColorAttribute(float r, float g, float b, float a = 1)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }


    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class GUI_EnableIfAttribute : BaseAttribute
    {
        public string fieldName;
        public object value;

        public GUI_EnableIfAttribute(string fieldName,object value)
        {
            this.fieldName = fieldName;
            this.value = value;
        }
    }


    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct, AllowMultiple = false)]
    public class GUI_LabelTextAttribute : BaseAttribute
    {
        public string labelName;
        public GUI_LabelTextAttribute(string labelName)
        {
            this.labelName = labelName;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct, AllowMultiple = false)]
    public class GUI_LabelWidthAttribute : BaseAttribute
    {
        public int labelWidth;
        public GUI_LabelWidthAttribute(int width)
        {
            this.labelWidth = width;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct, AllowMultiple = false)]
    public class GUI_DisableAttribute : BaseAttribute
    {
        public GUI_DisableAttribute()
        {
           
        }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct, AllowMultiple = false)]
    public class GUI_ReadOnlyAttribute : BaseAttribute
    {
        public GUI_ReadOnlyAttribute()
        {

        }
    }
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GUI_IntSliderAttribute : BaseAttribute
    {
        public int minValue;
        public int maxValue;
        public GUI_IntSliderAttribute(int min, int max)
        {
            this.minValue = min;
            this.maxValue = max;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GUI_FloatSliderAttribute : BaseAttribute
    {
        public float minValue;
        public float maxValue;
        public GUI_FloatSliderAttribute(float min, float max)
        {
            this.minValue = min;
            this.maxValue = max;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class GUI_DrawerAttribute : BaseAttribute
    {
        public Type drawerType;
        public GUI_DrawerAttribute(Type type)
        {
            this.drawerType = type;
        }
    }
}
