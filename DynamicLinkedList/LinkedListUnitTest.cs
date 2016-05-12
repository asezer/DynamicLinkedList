using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicLinkedList
{
    [TestClass]
    public class LinkedListUnitTest
    {
        [TestMethod]
        public void Create_DynamicLinkedList_Created()
        {
            var dynamicLinkedList = new DynamicLinkedList();
            dynamicLinkedList.Add("A");
            dynamicLinkedList.Add("2");
            dynamicLinkedList.Add(2 ,true);
            
            Assert.IsNotNull(dynamicLinkedList);
            Assert.AreEqual(3, dynamicLinkedList.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Retrive_OutOfRange_ExceptionThrown()
        {
            var dll = GetTestDynamicLinkedList();

            dll.Retrive(dll.Count() + 1);
        }

        [TestMethod]
        public void Update_DynamicLinkedListItem_Updated()
        {
            const string newValue = "BBB";

            var dll = GetTestDynamicLinkedList();
            var initialValue = dll.Retrive(2);

            dll.Update(2, newValue); // update second item

            Assert.AreNotEqual(initialValue, newValue);
            Assert.AreEqual(newValue, dll.Retrive(2));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Update_OutOfRange_ExceptionThrown()
        {
            var dll = GetTestDynamicLinkedList();

            dll.Update(dll.Count() + 1, "");
        }

        [TestMethod]
        public void Delete_DynamicLinkedListItem_Deleted()
        {
            var dll = GetTestDynamicLinkedList();

            var initialCount = dll.Count();

            dll.Delete(2); // delete a random item

            Assert.AreEqual(initialCount -1, dll.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Delete_OutOfRange_ExceptionThrown()
        {
            var dll = GetTestDynamicLinkedList();

            dll.Delete(dll.Count() + 1);
        }

        private static DynamicLinkedList GetTestDynamicLinkedList()
        {
            var dynamicLinkedList = new DynamicLinkedList();
            dynamicLinkedList.Add(1);
            dynamicLinkedList.Add(2);
            dynamicLinkedList.Add(3);
            dynamicLinkedList.Add(4);
            dynamicLinkedList.Add(5);
            dynamicLinkedList.Add("AAA");

            return dynamicLinkedList;
        }
    }
}
