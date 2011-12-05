using NUnit.Framework;
using ProtoBuf;

namespace ProtobufNet.Learning.Tests.Integration
{
    /// <summary>
    /// Learn through tests how protobuf-net behaves.
    /// 
    /// Lesson 4 Enums
    /// </summary>
    [TestFixture]
    public class Lesson4Enums:LessonBase
    {
        [Test]
        public void PublicEnum()
        {
            var instance = new Lesson4TestClass1() {Size = TestEnum1.Large};

            var result = PassThroughProtobuf(instance);

            Assert.AreEqual(TestEnum1.Large,result.Size);
        }

        [ProtoContract]
        public class Lesson4TestClass1
        {
            [ProtoMember(1)]
            public TestEnum1 Size { get; set; }
        }

        public enum TestEnum1
        {
            Small,Medium,Large,ExtraLarge
        }
    }
}
