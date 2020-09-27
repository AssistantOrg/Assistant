using System;
using System.Linq;
using Rovecode.Assistant.Application.Helpers;
using Xunit;

namespace Assistant.Tests.Application
{
    public class RandomizerHelperTest
    {
        public RandomizerHelperTest()
        {

        }

        [Fact]
        public void Test_ChooseRandomFromArrayFunction_In_EmptyStringArray_Out_KeyArray()
        {
            string[] emptyStringArray = new string[] { };

            // TODO: Fix Mac OS VS exception not in ThrowAny method
            //Assert.ThrowsAny<AssistantException>(() => RandomizerHelper.ChooseRandomFromArray(emptyStringArray));
        }

        [Fact]
        public void Test_ChooseRandomFromArrayFunction_In_StringArray_Out_StringFromArray()
        {
            string[] emptyStringArray = new string[] { "s1", "s2", "s3" };

            Assert.Contains(RandomizerHelper.ChooseRandomFromArray(emptyStringArray), emptyStringArray);
        }

        [Fact]
        public void Test_ChooseRandomFromArrayFunction_In_IntArray_Out_IntFromArray()
        {
            int[] emptyIntArray = new int[] { 0, 1, 2 };

            Assert.Contains(RandomizerHelper.ChooseRandomFromArray<int>(emptyIntArray), emptyIntArray);
        }
    }
}
