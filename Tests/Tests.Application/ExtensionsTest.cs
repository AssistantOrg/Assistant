//using System;
//using Assistant.Application.Extensions;
//using Xunit;

//namespace Assistant.Tests.Application
//{
//    public class ExtensionsTest
//    {
//        public ExtensionsTest()
//        {

//        }

//        [Fact]
//        public void Test_ToKeyExtension_In_CrazyString_Out_KeyArray()
//        {
//            const string crazyStr = "HELLO     hEllO  Привет ПривЕт !№%№%:.(;%Hi  !№%№%:.(;Ку  43423 000_T_T_000 000_Я_Я_000";
            
//            Assert.Equal(crazyStr.ToKey(), new [] { "hello", "hello", "привет", "привет", "hi", "ку", "43423", "000", "tt", "000", "000", "яя", "000" });
//        }

//        [Fact]
//        public void Test_ToKeyExtension_In_EmptyString_Out_EmptyKeyArray()
//        {
//            const string str = "";

//            Assert.Equal(str.ToKey(), new string[] { });
//        }

//        [Fact]
//        public void Test_ToKeyExtension_In_NullString_Out_EmptyKeyArray()
//        {
//            const string str = null;

//            Assert.Equal(str.ToKey(), new string[] { });
//        }
//    }
//}
