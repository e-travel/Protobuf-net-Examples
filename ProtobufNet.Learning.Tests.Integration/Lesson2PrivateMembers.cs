using NUnit.Framework;
using ProtoBuf;

namespace ProtobufNet.Learning.Tests.Integration
{
    /// <summary>
    /// Learn through tests how protobuf-net behaves.
    /// 
    /// Lesson 2 really private stuff
    /// </summary>
    [TestFixture]
    public class Lesson2PrivateMembers:LessonBase
    {
        [Test]
        public void PrivateProperty()
        {
            var instance = new Lesson2TestClass1("l2name1", "l2phone1");

            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("l2name1", result.GetName());
        }

        [Test]
        public void PrivateField()
        {
            var instance = new Lesson2TestClass1("l2name2", "l2phone2");

            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("l2phone2", result.GetPhone());
        }

        [ProtoContract]
        public class Lesson2TestClass1
        {
            /// <summary>
            /// Protobuf needs a parameterless constructor.
            /// 
            /// It can be private or public depending on your needs
            /// </summary>
            private Lesson2TestClass1()
            {
            }

            public Lesson2TestClass1(string name, string phone)
            {
                Name = name;
                _phone = phone;
            }

            public string GetName()
            {
                return Name;
            }

            public string GetPhone()
            {
                return _phone;
            }

            [ProtoMember(1)]
            private string Name { get; set; }

            [ProtoMember(2)]
            private string _phone;
        }
    }
}
