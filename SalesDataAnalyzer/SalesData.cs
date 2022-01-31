using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SalesDataAnalyzer
{
    public class Data //create a class for all of the variables
    {
        private int _Quantity;
        private string _Description, _InvoiceDate, _Country, _InvoiceNo, _CustomerID, _StockCode;
        private float _UnitPrice;

        public Data(string invoiceNo, string stockCode, string description, int quantity, string invoiceDate, float unitPrice, string customerID, string country)
        {
            InvoiceNo = invoiceNo;
            StockCode = stockCode;
            Description = description;
            Quantity = quantity;
            InvoiceDate = invoiceDate;
            CustomerID = customerID;
            UnitPrice = unitPrice;
            Country = country;


        }
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }
        public string StockCode
        {
            get { return _StockCode; }
            set { _StockCode = value; }
        }
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        public float UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

    }
}