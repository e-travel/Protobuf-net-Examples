using NUnit.Framework;
using ProtoBuf;
using ProtoBuf.Meta;

namespace ProtobufNet.Learning.Tests.Integration
{
    public class Lesson6Inheritance:LessonBase
    {
        #region Test1 Base class knows about the super class
        [Test]
        public void BaseClassKnowsAboutSuperClass()
        {
            var instance = new Lesson6SuperClass1
                               {
                                   Name ="Test1Name",
                                   Phone = "Test1Phone"
                               };
            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("Test1Name",result.Name);
            Assert.AreEqual("Test1Phone",result.Phone);
        }

        [ProtoContract]
        [ProtoInclude(100, typeof(Lesson6SuperClass1))]
        public class Lesson6BaseClass1
        {
            [ProtoMember(1)]
            public string Name { get; set; }
        }

        [ProtoContract]
        public class Lesson6SuperClass1:Lesson6BaseClass1
        {
            [ProtoMember(1)]
            public string Phone { get; set; }
        }
        #endregion

        #region Test2 When the base class cannot know about the super class
        [Test]
        public void BaseClassDoesntKnow()
        {
            // Here you need to configure the runtime to
            // work with it
            ProtobufTypeModel
                .Add(typeof (Lesson6BaseClass2), true)
                .AddSubType(100, typeof (Lesson6SuperClass2));
            

            var instance = new Lesson6SuperClass2
            {
                Name = "Test2Name",
                Phone = "Test2Phone"
            };
            var result = PassThroughProtobuf(instance);

            Assert.AreEqual("Test2Phone", result.Phone);
            Assert.AreEqual("Test2Name", result.Name);
        }

        [ProtoContract]
        public class Lesson6BaseClass2
        {
            [ProtoMember(2)]
            public string Name { get; set; }
        }

        [ProtoContract]
        public class Lesson6SuperClass2 : Lesson6BaseClass2
        {
            [ProtoMember(1)]
            public string Phone { get; set; }
        }
        #endregion

        #region Test3 Here we use the base class to ser/des and we get the superclass
        [Test]
        public void BaseClassDoesntKnowUsingBaseClass()
        {
            // Here you need to configure the runtime to
            // work with it
            ProtobufTypeModel
                .Add(typeof(Lesson6BaseClass3), true)
                .AddSubType(100, typeof(Lesson6SuperClass3));


            Lesson6BaseClass3 instance = new Lesson6SuperClass3
            {
                Name = "Test3Name",
                Phone = "Test3Phone"
            };
            var result = PassThroughProtobuf(instance) as Lesson6SuperClass3;
            
            Assert.AreEqual("Test3Phone", result.Phone);
            Assert.AreEqual("Test3Name", result.Name);
        }

        [ProtoContract]
        public class Lesson6BaseClass3
        {
            [ProtoMember(2)]
            public string Name { get; set; }
        }

        [ProtoContract]
        public class Lesson6SuperClass3 : Lesson6BaseClass3
        {
            [ProtoMember(1)]
            public string Phone { get; set; }
        }
        #endregion

        #region Test4 What if we use the base class object
        [Test]
        public void UsingBaseClassObject()
        {
            var instance = new Lesson6Test4Class1
                               {
                                   Something = new Lesson6Test4Class2
                                                   {
                                                       Name ="Test4Name"
                                                   }
                               };
            var result = PassThroughProtobuf(instance);
            Assert.AreEqual("Test4Name", ((Lesson6Test4Class2)result.Something).Name);
        }

        [Test]
        public void UsingBaseClassObjectSetNull()
        {
            var instance = new Lesson6Test4Class1
            {
                Something = null
            };
            var result = PassThroughProtobuf(instance);
            Assert.IsNull(result.Something);
        }
        [ProtoContract]
        public class Lesson6Test4Class1
        {
            [ProtoMember(1,DynamicType = true)]
            public object Something { get; set; }
        }
        [ProtoContract]
        public class Lesson6Test4Class2
        {
            [ProtoMember(1)]
            public string Name { get; set; }
        }
        #endregion
    }
}
