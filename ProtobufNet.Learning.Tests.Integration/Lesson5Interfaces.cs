using System.Collections.Generic;
using NUnit.Framework;
using ProtoBuf;

namespace ProtobufNet.Learning.Tests.Integration
{
    /// <summary>
    /// Learn through tests how protobuf-net behaves.
    /// 
    /// Lesson 5 Different interfaces
    /// </summary>
    [TestFixture]
    public class Lesson5Interfaces:LessonBase
    {
        #region IList 
        [Test]
        public void IList()
        {
            var instance = new Lesson5TestClass1
                               {
                                   Names = new List<string> {"Javier", "Juan"}
                               };
            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("Javier", result.Names[0]);
            Assert.AreEqual("Juan", result.Names[1]);
            Assert.AreNotSame(instance.Names, result.Names);
        }

        [ProtoContract]
        public class Lesson5TestClass1
        {
            [ProtoMember(1)]
            public IList<string> Names { get; set; }
        }
        #endregion

        #region Interface as member
        [Test]
        public void ZInterfaceAsMember()
        {
            var instance = new Lesson5TestClass3Wrapper
            {
                Person = new Lesson5TestClass3 {
                                   Name = "l5name3",
                                   Phone = "l5phone3"
                               }
            };
            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("l5name3", result.Person.Name);
            Assert.AreEqual("l5phone3", result.Person.Phone);
        }

        [ProtoContract]
        public class Lesson5TestClass3Wrapper
        {
            [ProtoMember(1)]
            public ILesson5TestInteface2 Person { get; set; }
        }

        [ProtoContract]
        public class Lesson5TestClass3 : ILesson5TestInteface2
        {
            [ProtoMember(1)]
            public string Name { get; set; }
            [ProtoMember(2)]
            public string Phone { get; set; }
        }

        [ProtoContract]
        [ProtoInclude(1000, typeof(Lesson5TestClass3))]
        public interface ILesson5TestInteface2
        {
            [ProtoMember(1)]
            string Name { get; set; }
            [ProtoMember(2)]
            string Phone { get; set; }
        }
        #endregion

        #region Interface as root object
        [Test]
        public void InterfaceAsRootObject()
        {
            //RuntimeTypeModel.Default.Add(typeof (ILesson5TestInteface1), true)
            //    .AddSubType(50, typeof(Lesson5TestClass2));

            ILesson5TestInteface1 instance = new Lesson5TestClass2
            {
                Name = "l5name2",
                Phone = "l5phone2"
            };
            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("l5name2", result.Name);
            Assert.AreEqual("l5phone2", result.Phone);
        }

        [ProtoContract]
        public class Lesson5TestClass2 : ILesson5TestInteface1
        {
            [ProtoMember(1)]
            public string Name { get; set; }
            [ProtoMember(2)]
            public string Phone { get; set; }
        }

        [ProtoContract]
        [ProtoInclude(1000, typeof(Lesson5TestClass2))]
        public interface ILesson5TestInteface1
        {
            [ProtoMember(1)]
            string Name { get; set; }
            [ProtoMember(2)]
            string Phone { get; set; }
        }
        #endregion
    }
}
