using Newtonsoft.Json;
using System;

namespace ExamPreparation.IntegrationTests.Models
{
    public static class Serialize
    {
        public static string ToJson(this Book self) => JsonConvert.SerializeObject(self, ExamPreparation.IntegrationTests.Models.Converter.Settings);

        public static string ToJson(this Author self) => JsonConvert.SerializeObject(self, ExamPreparation.IntegrationTests.Models.Converter.Settings);
    }
}
