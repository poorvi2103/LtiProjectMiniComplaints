using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Complaints
{
    class Complaints
    {
        public string Date_Received { get; set; }
        public string Product { get; set; }

        public string SubProduct { get; set; }

        public string Issue { get; set; }
        public string SubIssue { get; set; }

        public string Company { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
        public string MethodOfSubmission { get; set; }

        public string DateSentToCompany { get; set; }
        public string CompanyResponseToConsumer { get; set; }

        public bool IsResponseOnTime { get; set; }

        public bool IsConsumerDisputed { get; set; }

        public string ComplaintId { get; set; }

        public override string ToString()
        {
            string r = $" \n DataReceived : {Date_Received} \n Product : {Product} \n SubProduct : {SubProduct} \n Issue : {Issue} \n SubIssue : {SubIssue} \n Company : {Company} \n State : {State} \n ZipCode : {ZipCode} \n Method Of Submission : {MethodOfSubmission} \n Date Sent To Company : {DateSentToCompany} \n Company Response To Consumer : {CompanyResponseToConsumer} \n Is Response On Time : {IsResponseOnTime} \n Is Consumer Disputed : {IsConsumerDisputed} \n Complaint Id : {ComplaintId} \n\n";
            return r;
        }

    }
}
