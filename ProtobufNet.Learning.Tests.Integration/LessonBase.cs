using System;
using System.IO;
using NUnit.Framework;
using ProtoBuf.Meta;
using ProtobufNet.Learning.Tests.Integration.Helpers;

namespace ProtobufNet.Learning.Tests.Integration
{
    [TestFixture]
    public class LessonBase
    {
        /// <summary>
        /// For each test we use a clean type model.
        /// So you can change it on each test and it won't modify other tests.
        /// </summary>
        protected RuntimeTypeModel ProtobufTypeModel;

        [SetUp]
        public void SetUp()
        {
            ProtobufTypeModel = TypeModel.Create();
        }

        /// <summary>
        /// Serializes and deserializes an object using protobuf-net
        /// 
        /// It also checks that the returned object is not the same
        /// object than the one given. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        protected T PassThroughProtobuf<T>(T instance)
        {
            // Serialize
            var memoryStream = new MemoryStream();
            ProtobufTypeModel.Serialize(memoryStream, instance);
            // Deserialize
            memoryStream.Seek(0, SeekOrigin.Begin);
            var result = (T) ProtobufTypeModel.Deserialize(memoryStream, null, typeof (T));
            // Small reference test
            Assert.AreNotSame(instance,result);
            // If you want to know what is being generated
            Console.WriteLine(HexDump.Dump(memoryStream.ToArray()));

            return result;
        }
    }
}