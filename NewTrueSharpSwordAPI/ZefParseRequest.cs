using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;



namespace NewTrueSharpSwordAPI.Queries
{   
   
    public class ZefParseRequest
    {
        private zefCoreRequest DeepRequest;
        private zefMapNames Names;
        /// <summary>
        /// Diese Liste enthaelt in jedem XmlDokument ein Zefania XML Abfragemodul entsprechend der Abrage.
        /// </summary>
        private List<XmlDocument> QueryResultsXmlDocs = new List<XmlDocument>();

        public delegate void PQueryFinished(object sender, List<XmlDocument> QueryResults);
        /// <summary>
        /// Dieses Ereignis wird aufgerufen, wenn eine Abfrage beendet ist.
        /// </summary>
        public event PQueryFinished OnParseQueryFinished;

        
        public ZefParseRequest() {

            DeepRequest = new zefCoreRequest();
            Names = new zefMapNames("bnames.xml");
            DeepRequest.OnQueryFinished += new zefCoreRequest.QueryFinished(DeepRequest_OnQueryFinished);
        
        }

        void DeepRequest_OnQueryFinished(object sender, List<System.Xml.XmlDocument> QueryResults)
        {
            if (OnParseQueryFinished != null) {

                OnParseQueryFinished(this, QueryResults);
            
            }
        }

        public void GetQuery(string Query, List<string> PathsToCaches) {

            List<string> InternList = new List<string>();
            int MyIndex = -1;
            string[] VersItemArray;
            string tmp;
            List<string> MyQuery = new List<string>();

            try
            {
                VersItemArray = Query.Split(';');
                
                foreach (string item in VersItemArray) {

                    
                    MyQuery.Add(item);
                
                }

                foreach (string item in MyQuery) {
                    MyIndex++;
                    InternList.AddRange(ParseSingleQueryItem(item));
                }

                DeepRequest.GetResults(InternList, PathsToCaches);

            }
            catch (Exception e) {
            
            
            }
        
        }

        private List<string> ParseSingleQueryItem(string item)
        {
            List<string> InternList=new List<string>();
            List<string> ExpandesChapters = new List<string>();
            item = Regex.Replace(item, @"\s{1,}", "");
            string tmp=Regex.Replace(item, @"^[1-5|1-5\.|\D][\D]*","");

            string BN = item.Replace(tmp, "");

            if (BN.IndexOf(".") > -1)
            {
                BN = BN.Replace(".", " ");
            }
            else {

                BN = Regex.Replace(BN, @"^([1-5])", @"$1 ");
            }

            BN=BN.ToLower();
            if (BN.IndexOf(" ") != -1)
            {
                string temp1 = BN.Substring(BN.IndexOf(" ")+1, 1);
                BN = BN.Remove(BN.IndexOf(" ") + 1, 1);
                BN=BN.Insert(BN.IndexOf(" ")+1,temp1.ToUpper());

            }
            else {
                string temp2 = BN.Substring(0, 1);
                BN = temp2.ToUpper() + BN.Remove(0, 1);
            
            }
            BN = Names.GetBookNumber(BN);


            string CN = tmp.Substring(0, tmp.IndexOf(","));

            string VN=tmp.Substring(tmp.IndexOf(",")+1);

            item = BN + ":" + CN + ":" + VN;

            ExpandesChapters.AddRange(GetExpandedChapters(item));


            InternList.AddRange(ExpandesChapters);

            return InternList;
        }

        private List<string> GetExpandedChapters(string item)
        {
            List<string> InterneList = new List<string>();
            List<string> InterneList2 = new List<string>();
            string BN = string.Empty, CN = string.Empty, VN = string.Empty;
            string[] VersItemArray;
            VersItemArray = item.Split(':');
            BN = VersItemArray[0]; CN = VersItemArray[1]; VN = VersItemArray[2];

            string[] CNItemArray;
            if (CN.Contains("."))
            {

                CNItemArray = CN.Split('.');
                foreach (string s in CNItemArray)
                {

                    InterneList.Add(BN + ":" + s + ":" + VN);

                }


            }// if "."
            else {

                InterneList.Add(BN + ":" +CN + ":" + VN);
            }

            foreach (string item2 in InterneList) {

                VersItemArray = item2.Split(':');
                BN = VersItemArray[0]; CN = VersItemArray[1]; VN = VersItemArray[2];
                if (CN.Contains("-"))
                {

                    int a = Convert.ToInt16(CN.Substring(0, CN.IndexOf("-")));
                    int b = Convert.ToInt16(CN.Substring(CN.IndexOf("-")+1));
                    for (int i = a; i <= b; i++)
                    {
                        InterneList2.Add(BN + ":" + i.ToString() + ":" + VN);
                    }


                }
                else {

                    InterneList2.Add(BN + ":" + CN + ":" + VN);
                
                }

              
            
            }

            return  GetExpandedVerses(InterneList2);


        }

        private List<string> GetExpandedVerses(List<string> items)
        {
            List<string> InterneList = new List<string>();
            List<string> InterneList2 = new List<string>();
            string BN = string.Empty, CN = string.Empty, VN = string.Empty;
            string[] VersItemArray;

            foreach (string item in items)
            {
                VersItemArray = item.Split(':');
                BN = VersItemArray[0]; CN = VersItemArray[1]; VN = VersItemArray[2];

                string[] VNItemArray;

                if (VN.Contains("."))
                {

                    VNItemArray = VN.Split('.');
                    foreach (string s in VNItemArray)
                    {

                        InterneList.Add(BN + ":" + CN + ":" + s);

                    }


                }// if "."
                else
                {

                    InterneList.Add(BN + ":" + CN + ":" + VN);
                }

                foreach (string item2 in InterneList)
                {

                    VersItemArray = item2.Split(':');
                    BN = VersItemArray[0]; CN = VersItemArray[1]; VN = VersItemArray[2];
                    if (VN.Contains("-"))
                    {

                        int a = Convert.ToInt16(VN.Substring(0, VN.IndexOf("-")));
                        int b = Convert.ToInt16(VN.Substring(VN.IndexOf("-") + 1));
                        for (int i = a; i <= b; i++)
                        {
                            InterneList2.Add(BN + ":" + CN + ":" + i.ToString());
                        }


                    }
                    else
                    {

                        InterneList2.Add(BN + ":" + CN + ":" + VN);

                    }



                }
            }// end foreach (string item in items)
            return InterneList2;


        } 
    }
}
