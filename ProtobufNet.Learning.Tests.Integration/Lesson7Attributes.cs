using System;
using NUnit.Framework;

namespace ProtobufNet.Learning.Tests.Integration
{
    public class Lesson7Attributes:LessonBase
    {
        #region WithoutAnyAttribute_OneByOne
        [Test]
        public void WithoutAnyAttribute_OneByOne()
        {
            ProtobufTypeModel
                .Add(typeof (Lesson7Test1Class1), false)
                .Add(1, "Test");
            ProtobufTypeModel
                .Add(typeof(Lesson7Test1Class2), false)
                .Add(1, "Name");
            var instance = new Lesson7Test1Class1
            {
                Test = new Lesson7Test1Class2 { Name = "Test1Name" }
            };
            var result = PassThroughProtobuf(instance);
            Assert.AreEqual("Test1Name", result.Test.Name);
        }

        public class Lesson7Test1Class1
        {
            public Lesson7Test1Class2 Test { get; set; }
        }

        public class Lesson7Test1Class2
        {
            public String Name { get; set; }
        }
        #endregion

        #region WithoutAnyAttribute_UsingAList
        [Test]
        public void WithoutAnyAttribute_Many()
        {
            ProtobufTypeModel
                .Add(typeof(Lesson7Test2Class1), false)
                .Add(new string[] { "Test" });
            ProtobufTypeModel
                .Add(typeof(Lesson7Test2Class2), false)
                .Add(new string[] { "Name" });
            var instance = new Lesson7Test2Class1
            {
                Test = new Lesson7Test2Class2 { Name = "Test2Name" }
            };
            var result = PassThroughProtobuf(instance);
            Assert.AreEqual("Test2Name", result.Test.Name);
        }

        public class Lesson7Test2Class1
        {
            public Lesson7Test2Class2 Test { get; set; }
        }

        public class Lesson7Test2Class2
        {
            public String Name { get; set; }
        }
        #endregion

        #region Without Any Attribute Enum
        [Test]
        public void WithoutAnyAttribute_Enum()
        {
            ProtobufTypeModel
                .Add(typeof(Lesson7Test3Class1), false)
                .Add(new string[] { "Test" });
            ProtobufTypeModel
                .Add(typeof (Lesson7Test3Enum), false)
                .EnumPassthru = true;

            var instance = new Lesson7Test3Class1
            {
                Test = Lesson7Test3Enum.Three
            };
            var result = PassThroughProtobuf(instance);
            Assert.AreEqual(Lesson7Test3Enum.Three,result.Test);
        }

        public class Lesson7Test3Class1
        {
            public Lesson7Test3Enum Test { get; set; }
        }

        public enum Lesson7Test3Enum
        {
            One,Two,Three
        }
        #endregion
    }
}
