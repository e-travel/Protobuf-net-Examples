using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProtoBuf;

namespace ProtobufNet.Learning.Tests.Integration
{
    public class Lesson8Types:LessonBase
    {
        #region Empty lists are serialized as nulls unless the default constructor build it.
        [Test]
        public void EmptyListIsNull()
        {
            var instance = new Lesson8Test1 {MyList = new List<string>()};
            var result = PassThroughProtobuf(instance);
            Assert.IsNull(result.MyList);
        }

        [Test]
        public void EmptyListWithDefaultConstructorIsEmptyAndNotNull()
        {
            var instance = new Lesson8Test2();
            var result = PassThroughProtobuf(instance);
            Assert.IsNotNull(result.MyList);
            Assert.IsEmpty(result.MyList);
        }

        [ProtoContract]
        public class Lesson8Test1
        {
            [ProtoMember(1)]
            public List<string> MyList { get; set; }
        }

        [ProtoContract]
        public class Lesson8Test2
        {
            public Lesson8Test2()
            {
                MyList = new List<string>();
            }

            [ProtoMember(1)]
            public List<string> MyList { get; set; }
        }
        #endregion
    }
}
