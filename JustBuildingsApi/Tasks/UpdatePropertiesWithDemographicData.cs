using System.Text.Json;
using JustBuildingsApi.Interfaces;
using JustBuildingsApi.Models;

namespace JustBuildingsApi.Tasks
{
    public class UpdatePropertiesWithDemographicData : IUpdateProperties
    {
        public void AddDemographicData(Properties properties)
        {
            //TODO: Get API v2/demographics endpoint API key depending on deployment environment
            // i.e. if local deploy, get from local environment variable that is not source controlled
            // if CI/CD pipeline, get from CI pipeline environment variables depending on test/prod environment

            //TODO: Create task in new class to use API key and HttpClient to make request to get demographic data

            CreateFakeDemographicDataForPrototype(properties);
        }

        private static void CreateFakeDemographicDataForPrototype(Properties properties)
        {
            //FIXME: Figure out why failing to deserialize string
            // var jsonString = "{  \"type\": \"Demographics\",    \"attributes\": {      \"income\": {        \"label\": \"Income\",        \"type\": \"standalone\",        \"variables\": [          {            \"variable\": \"avg_household_income\",            \"value\": 88555.1858,            \"label\": \"Average household income\"          },          {            \"variable\": \"avg_individual_income\",            \"value\": 39706.2035,            \"label\": \"Average individual income\"          }        ]      },      \"commute_mode\": {        \"label\": \"Commute mode\",        \"type\": \"percent\",        \"variables\": [          {            \"variable\": \"transit\",            \"value\": 0.3483,            \"label\": \"Public transit\"          },          {            \"variable\": \"foot\",            \"value\": 0.271,            \"label\": \"Foot\"          },          {            \"variable\": \"bicycle\",            \"value\": 0.115,            \"label\": \"Bicycle\"          },          {            \"variable\": \"drive\",            \"value\": 0.2339,            \"label\": \"Car\"          }        ]      }    }  }";
            // var additionalData = JsonSerializer.Deserialize<AdditionalData>(jsonString);

            var additionalData = new AdditionalData();
            additionalData.Type = "Demographics";

            var averageHouseHoldIncome = new VariablePoint();
            averageHouseHoldIncome.Variable = "avg_household_income";
            averageHouseHoldIncome.Value = 88555.1858m;
            averageHouseHoldIncome.Label = "Average household income";

            var averageIndividualIcome = new VariablePoint();
            averageIndividualIcome.Variable = "avg_individual_income";
            averageIndividualIcome.Value = 39706.2035m;
            averageIndividualIcome.Label = "Average individual income";

            var income = new MetaData();
            income.Label = "Income";
            income.Type = "standalone";
            income.Variables = new VariablePoint[] { averageHouseHoldIncome, averageIndividualIcome };

            var publicTransit = new VariablePoint();
            publicTransit.Variable = "transit";
            publicTransit.Value = 0.3483m;
            publicTransit.Label = "Public transit";

            var foot = new VariablePoint();
            foot.Variable = "foot";
            foot.Value = 0.271m;
            foot.Label = "Foot";

            var bicycle = new VariablePoint();
            bicycle.Variable = "bicycle";
            bicycle.Value = 0.115m;
            bicycle.Label = "Bicycle";

            var car = new VariablePoint();
            car.Variable = "drive";
            car.Value = 0.2339m;
            car.Label = "Car";

            var commuteMode = new MetaData();
            commuteMode.Label = "commuteMode";
            commuteMode.Type = "percent";
            commuteMode.Variables = new VariablePoint[] { publicTransit, foot, bicycle, car };

            var attributes = new Attributes();
            attributes.Income = income;
            attributes.Commute_mode = commuteMode;

            additionalData.Attributes = attributes;
            properties.AdditionalData = additionalData;
        }
    }
}