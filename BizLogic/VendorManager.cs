using CentralAdministration.Contracts.DataContracts;
using CentralAdministration.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using update4u.SPS.DataLayer;

namespace CentralAdministration.BizLogic
{
    public class VendorManager : IVendorManager, IDisposable
    {
        private static readonly Vendor[] vendors =
        {
            new Vendor (Guid.Parse("b78d9fa5-26fe-4ebd-9c3a-ae2e7f084d53"),"Labtagon GmbH","Labtagon"),
            new Vendor (Guid.Parse("a0ff55a3-9c8f-4b3c-9395-a76454804a3f"),"Innomea GmbH","Innomea")
        };

        private HttpClient client = new HttpClient();
        


        public async Task<RegistrationResult> Register(Guid[] vendorIds, string vendorCustomerReference)
        {
            RegistrationResult result = new RegistrationResult();  
            RegistrationDetail reigstrationDetails = GetRegistrationDetails();
            string body = JsonConvert.SerializeObject(reigstrationDetails);
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            
            foreach (Guid vendorid in vendorIds)
            {
               Vendor vendor = GetVendor(vendorid);
               Uri url = vendor.GetRegistrationUrl();
               HttpResponseMessage response = await  client.PostAsync(url.ToString(), content);
               string responseMessage = await response.Content.ReadAsStringAsync();
               if (response.IsSuccessStatusCode)
               {
                    result.RegistrationMessage = responseMessage;
                    return result;
               }
               else
               {
                     result.RegistrationMessage = $"Failed to send Registration to Vendor: {vendor.Name}\nResponse from registrationUrl was: {responseMessage} ";
                    return result;
               }
            }
            result.RegistrationMessage = $"No valid Vendor was found";
            return result;
        }

        private RegistrationDetail GetRegistrationDetails()
        {
            FragmentRequestBase fragmentRequest = new FragmentRequestBase(SPSDataEngineSchemaReader.ClassGetIDFromName("CAExtensionClassCentralAdministration"), ColumnSelectOption.All, null);
            fragmentRequest.IsSecured = update4u.SPS.DataLayer.Security.IsSecured.Unsecured;
            fragmentRequest.Where = "1=1";
            fragmentRequest.Load();
            if (fragmentRequest.DataSet.Tables[0].Rows.Count != 1) return null;
            RegistrationDetail registrationDetails = new RegistrationDetail();

            DataRow row = fragmentRequest.DataSet.Tables[0].Rows[0];
            registrationDetails.ContactPhone = row.Field<string>("ContactPhone");
            registrationDetails.ContactEmail = row.Field<string>("ContactEmail");
            registrationDetails.CompanyName = row.Field<string>("CompanyName");
            registrationDetails.ContactPhone = row.Field<string>("ContactPhone");
            registrationDetails.M42CustomerNumber = row.Field<string>("M42CustomerNumber");
            return registrationDetails;

        }

        public Vendor GetVendor(Guid vendorId)
        {
            return vendors.FirstOrDefault(v => v.Id == vendorId);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
