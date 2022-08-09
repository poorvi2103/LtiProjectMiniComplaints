using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace Project_Complaints
{
    class DataStructuresForUserQuery
    {
        public void displayListOfComplaintsBasedOnYear(List<Complaints> complaints, string year)
        {
            var dataset = (from cp in complaints where cp.DateSentToCompany.Substring(6) == year select cp);

            if (!dataset.Any())
            {
                throw new Exception("No records found");
            }
            Console.WriteLine($"Details of Complaints in year {year}");
            foreach (var cp in dataset)
            {
                Console.WriteLine(cp);
            }

        }

        public void displayListOfComplaintsBasedOnBank(List<Complaints> complaints, string BankName)
        {
            var dataset = (from cp in complaints where cp.Company == BankName select cp);

            if (!dataset.Any())
            {
                throw new Exception("No records found");
            }

            Console.WriteLine($"Details of Complaints made by Bank {BankName}");



            foreach (var cp in dataset)
            {
                Console.WriteLine(cp);
            }


        }

        public void displayComplaintById(List<Complaints> complaints, string c_id)
        {
            var dataset = (from cp in complaints where cp.ComplaintId == c_id select cp);
            if (!dataset.Any())
            {
                throw new Exception("No records found");
            }
            Console.WriteLine($"Details of Complaint with id:{c_id}");

            foreach (var cp in dataset)
            {
                Console.WriteLine(cp);
            }
        }

        public void displayNoOfDaysToCloseComplaintById(List<Complaints> complaints, string c_id)
        {
            var ds = (from cp in complaints where cp.ComplaintId == c_id select cp);

            if (!ds.Any())
            {
                throw new Exception("No records found");
            }
            Console.WriteLine($"No of days to close Complaint with id:{c_id}");
            foreach (var cp in ds)
            {
                string f_date = cp.Date_Received;
                string l_date = cp.DateSentToCompany;

                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime l_d = DateTime.ParseExact(l_date, new string[] { "mm.dd.yyyy", "mm-dd-yyyy", "mm/dd/yyyy" }, provider, DateTimeStyles.None);
                DateTime f_d = DateTime.ParseExact(f_date, new string[] { "mm.dd.yyyy", "mm-dd-yyyy", "mm/dd/yyyy" }, provider, DateTimeStyles.None);
                double days = l_d.Subtract(f_d).TotalDays;
                int no_of_days = Convert.ToInt32(days);
                Console.WriteLine(no_of_days);

            }
        }

        public void displayComplaintsClosedOrWithExplanation(List<Complaints> complaints)
        {
            var ds = (from cp in complaints where (cp.CompanyResponseToConsumer == "Closed" || cp.CompanyResponseToConsumer == "Closed with explanation") select cp);

            if (!ds.Any())
            {
                throw new Exception("No record found");
            }

            Console.WriteLine("Details of Complaints which are closed or closed with explanation:");
            foreach (var c in ds)
            {
                Console.WriteLine(c);
            }
        }

        public void displayComplaintsTimelyResponse(List<Complaints> complaints)
        {
            var ds = (from cp in complaints where cp.IsResponseOnTime == true select cp);

            if (!ds.Any())
            {
                throw new Exception("No record found");
            }

            Console.WriteLine("Details of Complaints which received timely response:");

            foreach (var c in ds)
            {
                Console.WriteLine(c);
            }
        }
        public void takenewcomplaint()
        {
            Console.WriteLine("Enter DataReceived :");
            string Date_Received_read = Console.ReadLine();
            Console.WriteLine("Enter Product : ");
            string Product_read = Console.ReadLine();
            Console.WriteLine("Enter  SubProduct :");
            string SubProduct_read = Console.ReadLine();
            Console.WriteLine("Enter Issue :");
            string Issue_read = Console.ReadLine();
            Console.WriteLine("Enter SubIssue :");
            string SubIssue_read = Console.ReadLine();
            Console.WriteLine("Enter  Company :");
            string Company_read = Console.ReadLine();
            Console.WriteLine("Enter State : ");
            string State_read = Console.ReadLine();
            Console.WriteLine("Enter ZipCode :");
            string ZipCode_read = Console.ReadLine();
            Console.WriteLine("Enter Method Of Submission :");
            string MethodOfSubmission_read = Console.ReadLine();
            Console.WriteLine("Enter Date Sent To Company:");
            string DateSentToCompany_read = Console.ReadLine();
            Console.WriteLine("Enter Company Response To Consumer:");
            string CompanyResponseToConsumer_read = Console.ReadLine();
            Console.WriteLine("Enter Is Response On Time: Yes/No");
            string IsResponseOnTime_read = Console.ReadLine();
            Console.WriteLine("Enter Is Consumer Disputed : yes/No");
            string IsConsumerDisputed_read = Console.ReadLine();
            Console.WriteLine("Enter Complaint Id:");
            string ComplaintId_read = Console.ReadLine();


            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\poorv\Downloads\Project_Complaints\Project_Complaints\Project_Complaints\complaints.csv", true))
                {
                    file.WriteLine(Date_Received_read + "," + Product_read + "," + SubProduct_read + "," + Issue_read + "," + SubIssue_read + "," + Company_read + "," + State_read + "," + ZipCode_read + "," + MethodOfSubmission_read + "," + DateSentToCompany_read + "," + CompanyResponseToConsumer_read + "," + IsResponseOnTime_read + "," + IsConsumerDisputed_read + "," + ComplaintId_read);
                }
                Console.WriteLine("Successfully Inserted");

            }
            catch(Exception ex)
            {
                throw new ApplicationException("there is some problem :", ex);
            }

        }

    }
}
