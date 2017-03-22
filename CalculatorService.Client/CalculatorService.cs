﻿using CalculatorService.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
    }
}
