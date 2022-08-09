using System;
using System.Collections;
using System.Collections.Generic;
namespace Project_Complaints
{
    class Program
    {
        public static List<Complaints> Complaints;
        public static void InitializeApp()
        {
        Reading_CSV_Complaints reader = new Reading_CSV_Complaints();
        Complaints = reader.GetComplaints();
        Console.WriteLine("Done Initialising.....");
        }
        public static void PrintMenu()
        {
            
            Console.WriteLine("\n**********************************Project Complaints**********************************");
            Console.WriteLine("1. Enter year to Display all the complaints based on the year provided");
            Console.WriteLine("2. Enter Bank Name to Display all the complaints based on the name of the bank ");
            Console.WriteLine("3. Enter Complaint_id to Display complaints based on the complaint id");
            Console.WriteLine("4. Enter Complaint_id to Display number of days took by the Bank to close the complaint");
            Console.WriteLine("5. Display all the complaints closed/closed with explanation  ");
            Console.WriteLine("6. Display all the complaints which received a timely response ");
            Console.WriteLine("7. Enter a new Complaint");
            Console.WriteLine("\n**************************************************************************************");
        }

        static void Main(string[] args)
        {
            try
            {
                InitializeApp();

                    PrintMenu();
                    int choice = Convert.ToInt32(Console.ReadLine());

                    DataStructuresForUserQuery userQuery = new DataStructuresForUserQuery();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter year:");
                        string year = Console.ReadLine();
                        userQuery.displayListOfComplaintsBasedOnYear(Complaints, year);
                        break;
                    case 2:
                        Console.WriteLine("Enter BankName:");
                        string bank_name = Console.ReadLine();
                        userQuery.displayListOfComplaintsBasedOnBank(Complaints, bank_name);
                        break;

                    case 3:
                        Console.WriteLine("Enter ComplaintId:");
                        string c_id = Console.ReadLine();
                        userQuery.displayComplaintById(Complaints, c_id);
                        break;

                    case 4:
                        Console.WriteLine("Enter ComplaintId:");
                        string cid = Console.ReadLine();
                        userQuery.displayNoOfDaysToCloseComplaintById(Complaints, cid);
                        break;

                    case 5:
                        userQuery.displayComplaintsClosedOrWithExplanation(Complaints);
                        break;
                    case 6:
                        userQuery.displayComplaintsTimelyResponse(Complaints);
                        break;

                    case 7:
                        userQuery.takenewcomplaint();
                        break;

                }
                Console.WriteLine("EOP");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
