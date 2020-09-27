//using System;
//using System.Collections.Generic;
//using Assistant.Facade.Configuration;
//using Assistant.Messages.Enums;
//using Newtonsoft.Json;
//using Bing = Assistant.Messages.Builders.Bing;
//using Xunit;
//using Assistant.Messages.Builders;

//namespace Tests.Messages
//{
//    class Options : IOptions
//    {
//        public string Language { get; set; } = "ru";

//        public IEnumerable<IEnumerable<string>> ExecuteAssistantKeys { get; set; } = new IEnumerable<string>[] { };

//        public string BingToken { get; set; }
//        public Uri BingLink { get; set; }
//    }

//    public class UnitTest1
//    {
//        [Fact]
//        public void Test1()
//        {
//            var ctx = new AssistantContextBuilder(new Options())
//                .SetText("test%№:")
//                .GetResult();

//            var result = new Bing.SearchImagesAttachmentBuilder(ctx)
//                .SetSearchKey(new[] { "test" })
//                .SetSafeSearch(SafeSearch.Selective)
//                .SetCount(2)
//                .GetResult();

//            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
//        }
//    }
//}
