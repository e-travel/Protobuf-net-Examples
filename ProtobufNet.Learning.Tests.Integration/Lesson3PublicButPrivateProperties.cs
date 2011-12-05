using NUnit.Framework;
using ProtoBuf;

namespace ProtobufNet.Learning.Tests.Integration
{
    /// <summary>
    /// Learn through tests how protobuf-net behaves.
    /// 
    /// Lesson 3 public properties with private set/get
    /// </summary>
    [TestFixture]
    public class Lesson3PublicButPrivateProperties:LessonBase
    {
        [Test]
        public void PublicFieldPrivateSetter()
        {
            var instance = new Lesson3TestClass1("l3name1");

            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("l3name1", result.Name);
        }

        [Test]
        public void PublicFieldPrivateGetter()
        {
            var instance = new Lesson3TestClass1("l3name2") {Phone = "l3phone2"};

            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("l3phone2", result.GetPhone());
        }

        [ProtoContract]
        public class Lesson3TestClass1
        {
            public Lesson3TestClass1()
            {
            }

            public Lesson3TestClass1(string name)
            {
                Name = name;
            }

            [ProtoMember(1)]
            public string Name { get; private set; }

            [ProtoMember(2)]
            public string Phone { private get; set; }

            public string GetPhone()
            {
                return Phone;
            }
        }
    }
}
