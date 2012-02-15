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

		[Test]
		public void NullableEnum()
		{
			// First pass, null value.
			var instance = new Lesson4TestClass2();
			var result = PassThroughProtobuf(instance);
			Assert.IsNull(result.Size);
			
			// Second pass, with value.
			instance.Size = TestEnum1.ExtraLarge;
			result = PassThroughProtobuf(instance);
			Assert.AreEqual(result.Size, TestEnum1.ExtraLarge);
		}

        [ProtoContract]
        public class Lesson4TestClass1
        {
            [ProtoMember(1)]
            public TestEnum1 Size { get; set; }
        }

		[ProtoContract]
		public class Lesson4TestClass2
		{
			[ProtoMember(1)]
			public TestEnum1? Size { get; set; }
		}

        public enum TestEnum1
        {
            Small,Medium,Large,ExtraLarge
        }
    }
}
