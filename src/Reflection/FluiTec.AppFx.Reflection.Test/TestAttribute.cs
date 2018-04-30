using System;

namespace FluiTec.AppFx.Reflection.Test
{
    public class TestAttribute : Attribute
    {
        public TestAttribute()
        {
        }

        public TestAttribute(string testText)
        {
            TestText = testText;
        }

        public string TestText { get; set; }
    }
}