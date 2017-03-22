using CalculatorService.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CalculatorService.Client
{
    public static class CalculatorService
    {
        private static string ENDPOINT = "http://localhost:2286/api/calculator/";

        public static string testAdd()
        {
            // Request Test Object
            AddRequest request = new AddRequest();
            request.Addends = new int[] { 1, 2, 3 };

            // Response Test Object
            AddResponse response;
            
            // Calling service...
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(String.Format("{0}{1}", ENDPOINT, "add"));
            Req.Method = "POST";
            Req.ContentType = "application/json";
            
            Req.Headers.Add("X-Evi-Tracking-Id", "12345678");

            using (var streamWriter = new StreamWriter(Req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(request);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            // Getting response...
            HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();

            StreamReader sr = new StreamReader(Resp.GetResponseStream(), Encoding.UTF8);

            string s = sr.ReadToEnd();
            sr.Close();
            Resp.Close();

            response = JsonConvert.DeserializeObject<AddResponse>(s);
            return response.Sum.ToString();            
        }

        public static string testSub()
        {
            // Request Test Object
            SubRequest request = new SubRequest();
            request.Minuend = 2;
            request.Subtrahend = 7;

            // Response Test Object
            SubResponse response;

            // Calling service...
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(String.Format("{0}{1}", ENDPOINT, "sub"));
            Req.Method = "POST";
            Req.ContentType = "application/json";

            Req.Headers.Add("X-Evi-Tracking-Id", "12345678");

            using (var streamWriter = new StreamWriter(Req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(request);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            // Getting response...
            HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();

            StreamReader sr = new StreamReader(Resp.GetResponseStream(), Encoding.UTF8);

            string s = sr.ReadToEnd();
            sr.Close();
            Resp.Close();

            response = JsonConvert.DeserializeObject<SubResponse>(s);
            return response.Difference.ToString();
        }

        public static string testMult()
        {
            // Request Test Object
            MultRequest request = new MultRequest();
            request.Factors = new int[] { 8, 3, 2 };            

            // Response Test Object
            MultResponse response;

            // Calling service...
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(String.Format("{0}{1}", ENDPOINT, "mult"));
            Req.Method = "POST";
            Req.ContentType = "application/json";

            Req.Headers.Add("X-Evi-Tracking-Id", "12345678");

            using (var streamWriter = new StreamWriter(Req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(request);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            // Getting response...
            HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();

            StreamReader sr = new StreamReader(Resp.GetResponseStream(), Encoding.UTF8);

            string s = sr.ReadToEnd();
            sr.Close();
            Resp.Close();

            response = JsonConvert.DeserializeObject<MultResponse>(s);
            return response.Product.ToString();
        }

        public static string testDiv()
        {
            // Request Test Object
            DivRequest request = new DivRequest();
            request.Dividend = 11;
            request.Divisor = 2;

            // Response Test Object
            DivResponse response;

            // Calling service...
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(String.Format("{0}{1}", ENDPOINT, "div"));
            Req.Method = "POST";
            Req.ContentType = "application/json";

            Req.Headers.Add("X-Evi-Tracking-Id", "12345678");

            using (var streamWriter = new StreamWriter(Req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(request);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            // Getting response...
            HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();

            StreamReader sr = new StreamReader(Resp.GetResponseStream(), Encoding.UTF8);

            string s = sr.ReadToEnd();
            sr.Close();
            Resp.Close();

            response = JsonConvert.DeserializeObject<DivResponse>(s);
            return " Quotient = " + response.Quotient.ToString() + " Remainder = " + response.Remainder.ToString();
        }

        public static string testSqrt()
        {
            // Request Test Object
            SqrtRequest request = new SqrtRequest();
            request.Number = 16;
            

            // Response Test Object
            SqrtResponse response;

            // Calling service...
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(String.Format("{0}{1}", ENDPOINT, "sqrt"));
            Req.Method = "POST";
            Req.ContentType = "application/json";

            Req.Headers.Add("X-Evi-Tracking-Id", "12345678");

            using (var streamWriter = new StreamWriter(Req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(request);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            // Getting response...
            HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();

            StreamReader sr = new StreamReader(Resp.GetResponseStream(), Encoding.UTF8);

            string s = sr.ReadToEnd();
            sr.Close();
            Resp.Close();

            response = JsonConvert.DeserializeObject<SqrtResponse>(s);
            return response.Square.ToString();
        }

        public static string testQuery()
        {
            // Request Test Object
            QueryRequest request = new QueryRequest();
            request.Id = 12345678;

            // Response Test Object
            QueryResponse response;

            // Calling service...
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(String.Format("{0}{1}", ENDPOINT, "query"));
            Req.Method = "POST";
            Req.ContentType = "application/json";            

            using (var streamWriter = new StreamWriter(Req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(request);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            // Getting response...
            HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();

            StreamReader sr = new StreamReader(Resp.GetResponseStream(), Encoding.UTF8);

            string s = sr.ReadToEnd();
            sr.Close();
            Resp.Close();

            response = JsonConvert.DeserializeObject<QueryResponse>(s);
            return JsonConvert.SerializeObject(response.Operations);
        }
    }
}
