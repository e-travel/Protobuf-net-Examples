using System;
using NUnit.Framework;
using ProtoBuf.Meta;

namespace ProtobufNet.Learning.Tests.Integration
{
    public class Lesson7Attributes:LessonBase
    {
        [Test,Ignore]
        public void WithoutAnyAttribute()
        {
            ProtobufTypeModel.AutoAddMissingTypes = true;
            
            var instance = new Lesson7Test1Class1 {Name="Test1Name"};
            var result = PassThroughProtobuf(instance);
            Assert.AreEqual("Test1Name", result.Name);
        }

        public class Lesson7Test1Class1
        {
            public String Name { get; set; }
        }
    }
}
