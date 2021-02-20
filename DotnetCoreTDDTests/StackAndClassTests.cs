using NUnit.Framework;
using DotnetCoreTDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDDTests
{
    /// <summary>
    /// Stack 和 Class 的差別
    /// <see cref="https://dotblogs.com.tw/daniel/2018/02/22/135011"/>
    /// <seealso cref="https://dotblogs.com.tw/daniel/2017/10/20/174725"/>
    /// </summary>
    [TestFixture()]
    class StackAndClassTests
    {
        public class Member
        {

        }

        public struct MyStruct
        {
            public Member member { get; set; }
        }

        #region struct 存在 Stack Memory
        [Test()]
        public void StructEqualsTest()
        {
            MyStruct s1 = new MyStruct();
            MyStruct s2 = new MyStruct();

            // struct 都存在 Stack memory，因為 s1、s2的內容都一樣，所以判斷為相同
            Assert.AreEqual(s1, s2);
        }

        [Test()]
        public void StructEqualsTest2()
        {
            MyStruct s1 = new MyStruct();
            MyStruct s2 = new MyStruct();

            s2.member = new Member();

            // s2 動態配置了 Heap 的記憶體給 member，但s1.member並沒有，所以兩者視為不同
            Assert.AreNotEqual(s1, s2);
        }

        [Test()]
        public void StructEqualsTest3()
        {
            MyStruct s1 = new MyStruct();
            MyStruct s2 = new MyStruct();

            var member = new Member();
            s1.member = member;
            s2.member = member;

            // s1, s2 都動態配置了相同的 Heap 的記憶體給 member，所以相等
            Assert.AreEqual(s1, s2);
        }
        #endregion

        # region class 存在 Heap Memory
        [Test()]
        public void ClassEqualsTest()
        {
            Member c1 = new Member();
            Member c2 = new Member();

            // c1, c2 被分配到不同的Heap Memory，對應回Stack Memory的位置也不同，所以不相等
            Assert.AreNotEqual(c1, c2);
        }
        #endregion

        #region 值類型與參考類型的差別
        public class ClassType
        {
            public int num { get; set; }
            public ClassType SetNum(int input)
            {
                num = input;
                return this;
            }
        }

        public struct StructType
        {
            public int num { get; set; }
            public StructType SetNum(int input)
            {
                num = input;
                return this;
            }
        }

        public class MyClass
        {
            public ClassType classType { get; set; }
            public StructType structType { get; set; }
        }

        [Test()]
        public void SetNumTest()
        {
            int target = 10;

            var myClass = new MyClass
            {
                classType = new ClassType(),
                structType = new StructType()
            };

            myClass.classType.SetNum(target);
            Assert.AreEqual(target, myClass.classType.num);


            // 當存取 myClass.structType 時，會先 clone 一個新的實例，造成 SetNum 是設定在新的實例上
            var newStructType = myClass.structType.SetNum(target);
            Assert.AreEqual(target, newStructType.num);
            Assert.AreEqual(0, myClass.structType.num);
        }

        public void IncreaseClassNum(ClassType obj)
        {
            obj.num++;
        }

        public void IncreaseStructNum(StructType obj)
        {
            obj.num++;
        }

        [Test()]
        public void IncreaseTest()
        {
            var structObj = new StructType { num = 1 };
            var classObj = new ClassType { num = 1 };

            // class會直接引用記憶體位置，而stack是複製一個一模一樣的過去但與本身為不同一個
            IncreaseStructNum(structObj);
            IncreaseClassNum(classObj);

            Assert.AreEqual(2, classObj.num);
            Assert.AreEqual(1, structObj.num);
        }
        #endregion
    }
}
