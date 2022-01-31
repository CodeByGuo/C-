using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SalesDataAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = ("salesData.csv");

            List<Data> SalesDataList = new List<Data>(); //Create a List to store varibales

            try
            {
                using (var dataReader = new StreamReader(filename))
                {
                    int lineNum = 1;
                    int dataNum = 8;
                    var lines = dataReader.ReadLine();
                    while (!dataReader.EndOfStream)
                    {
                        lineNum++;
                        lines = dataReader.ReadLine();

                        //split the values
                        var values = lines.Split(',');
                        if (values.Length != dataNum)
                        {
                            throw new Exception($"Row {lineNum} contains {values.Length} pieces of data. It should have {dataNum}");
                        }
                        try
                        {
                            //Create objects for the different types of datad 
                            string InvoiceNo = (values[0]);
                            string StockCode = (values[1]);
                            string Description = (values[2]);
                            int Quantity = Int32.Parse(values[3]);
                            string InvoiceDate = values[4];
                            float UnitPrice = Convert.ToSingle(values[5]);
                            string InvoiceCustomerIDNo = (values[6]);
                            string Country = values[7];



                            //create the object
                            Data data = new Data(InvoiceNo, StockCode, Description, Quantity, InvoiceDate, UnitPrice, InvoiceCustomerIDNo, Country);
                            SalesDataList.Add(data);




                        }
                        catch (Exception e)
                        {
                            throw new Exception(($"Row {lineNum} contains invalid data. ({e.Message})"));
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(($"There was an error reading the file {e.Message}"));
            }




            //Create Linqs foor the Prompt



            //1. Costumers in Australia
            var AUcustomers = from Data in SalesDataList where Data.Country == "Australia" select Data;
            Console.WriteLine("Items Sold in AU: \n");
            foreach (var customers in AUcustomers)
            {

                Console.WriteLine($"Item: {customers.Description.ToString()}\nStock Code: {customers.StockCode.ToString()}");

            }

            //2. How many individual sales were there? To determine this you have to count the unique invoice numbers. You should group by invoice number?

            var IndivisualSales = from data in SalesDataList where data.InvoiceNo.Contains("5") select data;
            int altNum = 0;
            foreach (var s in IndivisualSales)
            {

                altNum++;
            }
            Console.WriteLine($"\n\nIndividual Sales: {altNum}");




            //3. Sale total 
            var saleTotal = (from data in SalesDataList where data.InvoiceNo.Contains("536365") select (data.Quantity * data.UnitPrice)).Sum();
            Console.WriteLine($"\n\nTotal Sales from Item 536365: {saleTotal}");



            //4. Total Sales by Country



            //5. Customer Id Most Spent
            var MostSpent = (from data in SalesDataList where data.Quantity > 1 && data.UnitPrice > 1 orderby data.Quantity * data.UnitPrice descending select data).First();
            Console.WriteLine($"\n\nCustomer ID who spent the most: {MostSpent.CustomerID}");


            //6. Sales To Customer 15311
            var SalesToCustomer = (from data in SalesDataList where data.CustomerID.Contains("15311") select data).First();
            Console.WriteLine($"\n\nSales to CustomerID 15311: {SalesToCustomer.Quantity}");


            //7. How many units of “HAND WARMER UNION JACK” were sold in the dataset?
            var HandWarmer = from data in SalesDataList where data.Description.Contains("HAND WARMER UNION JACK") select data.Quantity.ToString();
            Console.WriteLine($"\n\nHow many units of “HAND WARMER UNION JACK” were sold: {HandWarmer.First()}");



            //8. What was the total value of the “HAND WARMER UNION JACK” sales in the dataset?
            var TotalValue = (from data in SalesDataList where data.Description.Contains("HAND WARMER UNION JACK") select data.UnitPrice * data.Quantity).Sum();
            Console.WriteLine($"\n\nTotal Value of HAND WARMER UNION JACK: {TotalValue}");



            //9. Which product has the highest UnitPrice (stockCode and Description).?
            var HighestPrice = SalesDataList.OrderByDescending(data => data.UnitPrice).First();
            Console.WriteLine($"\n\nHighest Priced Item: {HighestPrice.Description}");

            //10. What is the total sales for the entire dataset?




            //11. Which invoice number had the highest sales?
            var HighestSales = SalesDataList.OrderByDescending(data => data.Quantity).First();
            Console.WriteLine($"\n\nHighest Sold Item: {HighestSales.InvoiceNo}");



            //12. Products that were sold the most
            var MostSold = SalesDataList.OrderByDescending(data => data.Quantity).FirstOrDefault();
            Console.WriteLine($"\n\nProduct that Sold the Most Units: \nStock Code:{MostSold.StockCode} Description: {MostSold.Description}");


        }
    }
}
