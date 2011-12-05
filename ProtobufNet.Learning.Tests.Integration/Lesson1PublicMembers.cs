using System;
using NUnit.Framework;
using ProtoBuf;

namespace ProtobufNet.Learning.Tests.Integration
{
    /// <summary>
    /// Learn through tests how protobuf-net behaves.
    /// 
    /// Lesson 1 public stuff.
    /// </summary>
    [TestFixture]
    public class Lesson1PublicMembers : LessonBase
    {
        [Test]
        public void PublicProperty()
        {
            var instance = new Lesson1TestClass1 {Name = "test1"};

            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("test1",result.Name);
        }

        [Test]
        public void PublicField()
        {
            var instance = new Lesson1TestClass1 { Phone = "test2" };

            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("test2", result.Phone);
        }

        [Test]
        public void PublicReadonlyField()
        {
            var instance = new Lesson1TestClass1();
            // we keep the id to compare it later.
            var id = instance.Id;

            var result = PassThroughProtobuf(instance);

            Assert.AreEqual(id, result.Id);
        }

        [ProtoContract]
        public class Lesson1TestClass1
        {
            [ProtoMember(1)]
            public string Name { get; set; }

            [ProtoMember(2)]
            public string Phone;

            [ProtoMember(3)] 
            public readonly Guid Id = Guid.NewGuid();
        }
    }
}
