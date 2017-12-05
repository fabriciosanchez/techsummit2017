using System;
using System.Collections.Generic;
using System.IO;
using ZipUtilityStandard;
using ZipUtilityStandard.Utils;

namespace Demo1ZipperApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string selectedOption = string.Empty;
            int convertedOption = 0;

            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("-                              ZIPPER APP - A ZIP UTILITY BUILT IN .NET CORE                               -");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please, select the operation that you would like to execute. To choose, type operation number + 'Enter'.");
            Console.WriteLine("");
            Console.WriteLine("(0) To close the app");
            Console.WriteLine("(1) Create a new zip file based in a directory");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            
            selectedOption = Console.ReadLine();

            if(selectedOption == "0")
            {
                Environment.Exit(0);
            }
            else
            {
                if(!int.TryParse(selectedOption, out convertedOption))
                {
                    Console.WriteLine("Ops! Seems like the provided option is invalid. Please, select a valid option.");
                    Console.WriteLine("");
                }
                else
                {
                    switch(selectedOption)
                    {
                        case "1":
                            string pathToBeZipped = string.Empty;
                            string outputName = string.Empty;
                            string password = string.Empty;

                            GetInfoToGenerateZipBundle(out pathToBeZipped, out outputName, out password);

                            Console.WriteLine("Generating zip bundle. This operation can take some minutes...");

                            try
                            {
                                CreatesZipBundle(pathToBeZipped, outputName, password);
                                Console.WriteLine("Success! \nThe " + outputName + " was generated on the specified path.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ops! Something went wrong. The details are being showed below:\n" + ex.Message);
                            }
                        break;
                    }
                }
            }
        }

        private static void GetInfoToGenerateZipBundle(out string pathToBeZipped, out string outputName, out string password)
        {
            do
            {
                Console.WriteLine("Please, inform the path to directory that you would like to zip files: ");
                pathToBeZipped = Console.ReadLine();

                if (pathToBeZipped == null || pathToBeZipped == "")
                {
                    Console.WriteLine("Seems like you haven't informed the entry path. This information is required. So...");
                }

            } while (pathToBeZipped == null || pathToBeZipped == "");

            Console.WriteLine("Would you like to add some password to you file? If yes, please type it. If not, just press 'Enter'.");
            password = Console.ReadLine();

            do
            {
                Console.WriteLine("Please, inform the name of the zipped (output) file: ");
                outputName = Console.ReadLine();

                if (outputName == null || outputName == "")
                {
                    Console.WriteLine("Seems like you haven't informed the output name. This information is required. So...");
                }

            } while (outputName == null || outputName == "");

            CreatesZipBundle(pathToBeZipped, outputName, password);
        }

        private static void CreatesZipBundle(string pathToBeZipped, string outputName, string password)
        {
            if (!Directory.Exists(pathToBeZipped)) throw new DirectoryNotFoundException(nameof(pathToBeZipped));

            Create zipper = new Create();

            try
            {
                zipper.CreateZipBundle(outputName, password, pathToBeZipped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
